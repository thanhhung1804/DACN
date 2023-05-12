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
    public class RoleDAO
    {
        private SqlServerDatabase database;

        public RoleDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<RoleDTO> GetAll()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            string query = "select * from dbo.[Role]";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                RoleDTO role = new RoleDTO(row);
                roles.Add(role);
            }

            database.Disconnect();
            return roles;
        }
    }
}
