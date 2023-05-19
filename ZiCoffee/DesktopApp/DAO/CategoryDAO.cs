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
    public class CategoryDAO
    {
        private SqlServerDatabase database;

        public CategoryDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<CategoryDTO> GetAll()
        {
            string query = "select * from dbo.[Category]";

            List<CategoryDTO> categories = new List<CategoryDTO>();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                CategoryDTO category = new CategoryDTO(row);
                categories.Add(category);
            }
            return categories;
        }

        public bool Create(string name, string description = null)
        {
            string query = "insert into dbo.[Category] (CategoryId, Name, Description) values ( @categoryId , @name , @description )";

            Guid newCategoryId = Guid.NewGuid();
            List<object> parameters = new List<object>() { newCategoryId, name, description };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(Guid categoryId, string name, string description = null)
        {
            string query = "update dbo.[Category] set Name = @name , Description = @description where CategoryId = @categoryId";

            List<object> parameters = new List<object>() { name, description, categoryId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid categoryId)
        {
            string query = "delete from dbo.[Category] where CategoryId = @categoryId";

            List<object> parameters = new List<object>() { categoryId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
