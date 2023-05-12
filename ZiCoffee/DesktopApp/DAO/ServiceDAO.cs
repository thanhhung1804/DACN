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

        public List<ServiceDTO> GetAll()
        {
            List<ServiceDTO> services = new List<ServiceDTO>();
            string query = "select * from dbo.[Service]";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                ServiceDTO service = new ServiceDTO(row);
                services.Add(service);
            }

            database.Disconnect();
            return services;
        }
    }
}
