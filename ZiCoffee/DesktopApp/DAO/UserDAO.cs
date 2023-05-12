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
    public class UserDAO
    {
        private SqlServerDatabase database;

        public UserDAO() 
        { 
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<UserDTO> GetAll() 
        {
            List<UserDTO> users = new List<UserDTO>();
            string query = "select * from dbo.[User]";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows) 
            {
                UserDTO user = new UserDTO(row);
                users.Add(user);
            }

            database.Disconnect();
            return users;
        }
    }
}
