using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DAO
{
    public class ServiceDAO
    {
        private SqlServerDatabase database;

        public ServiceDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<ServiceDTO> GetAll(
            Guid categoryId,
            string keyword = null,
            ServiceStatus status = ServiceStatus.All)
        {
            string query = @"
                select s.ServiceId, s.Name, s.Description, s.Status, s.Price, s.Image, s.CategoryId, c.Name as CategoryName
                from dbo.[Service] as s, dbo.[Category] as c
                where s.CategoryId = c.CategoryId";

            List<object> parameters = new List<object>();
            if (!string.IsNullOrEmpty(keyword))
            {
                query += @" and ( 
                        upper(s.Name) like upper( @keyword1 ) 
                        or upper(s.Description) like upper( @keyword2 ) 
                        or upper(c.Name) like upper( @keyword3 )
                    )";
                keyword = string.Format("%{0}%", keyword);
                for (int i = 0; i < 3; i++)
                {
                    parameters.Add(keyword);
                }
            }
            if (categoryId != null && categoryId != Guid.Empty)
            {
                query += " and s.CategoryId = @categoryId";
                parameters.Add(categoryId);
            }
            if (status != ServiceStatus.All)
            {
                query += " and s.Status = @status";
                parameters.Add(status);
            }

            List<ServiceDTO> services = new List<ServiceDTO>();
            DataTable dataTable = database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                ServiceDTO service = new ServiceDTO(row);
                services.Add(service);
            }
            return services;
        }

        public bool Create(
            string name,
            Guid categoryId,
            ServiceStatus status = ServiceStatus.Unavailable,
            string description = null,
            float price = 0,
            byte[] image = null)
        {
            string query = @"
                insert into dbo.[Service] (ServiceId, Name, Description, Status, CategoryId, Price, Image) 
                values ( @serviceId , @name , @description , @status , @categoryId , @price , @image )";

            Guid newServiceId = Guid.NewGuid();
            List<object> parameters = new List<object> { 
                newServiceId, name, description, status, categoryId, price, image 
            };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(
            Guid serviceId,
            string name,
            Guid categoryId,
            ServiceStatus status = ServiceStatus.Unavailable,
            string description = null,
            float price = 0,
            byte[] image = null)
        {
            string query = @"
                update dbo.[Service] 
                set Name = @name , Description = @description , Status = @status , 
                    CategoryId = @categoryId , Price = @price , Image = @image 
                where ServiceId = @serviceId";

            List<object> parameters = new List<object> { 
                name, description, status, categoryId, price, image, serviceId 
            };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid serviceId)
        {
            string query = @"delete from dbo.[Service] where ServiceId = @serviceId";

            List<object> parameters = new List<object> { serviceId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
