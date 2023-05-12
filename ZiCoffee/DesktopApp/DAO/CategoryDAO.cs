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
            List<CategoryDTO> categories = new List<CategoryDTO>();
            string query = "select * from dbo.[Category]";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                CategoryDTO category = new CategoryDTO(row);
                categories.Add(category);
            }

            database.Disconnect();
            return categories;
        }
    }
}
