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
    public class RoleActionDAO
    {
        private SqlServerDatabase database;

        public RoleActionDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<RoleActionDTO> GetRoleActionMapping(Guid? roleId = null, Guid? actionId = null)
        {
            string query = @"select * from dbo.[RoleAction]";

            List<object> parameters = new List<object> { };
            if (roleId != null && actionId == null) 
            {
                query += " where RoleId = @roleId";
                parameters.Add(roleId);
            }
            if (roleId == null && actionId != null)
            {
                query += " where ActionId = @actionId";
                parameters.Add(actionId);
            }
            if (roleId != null && actionId != null)
            {
                query += " where RoleId = @roleId and ActionId = @actionId";
                parameters.Add(roleId);
                parameters.Add(actionId);
            }

            List<RoleActionDTO> roleActions = new List<RoleActionDTO>();
            DataTable dataTable = database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                RoleActionDTO roleAction = new RoleActionDTO(row);
                roleActions.Add(roleAction);
            }
            return roleActions;
        }

        public bool Create(Guid roleId, Guid actionId)
        {
            string query = @"insert into dbo.[RoleAction] (RoleId, ActionId) values ( @roleId , @actionId )";
            List<object> parameters = new List<object> { roleId, actionId };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid roleId, Guid actionId)
        {
            string query = @"delete dbo.[RoleAction] where RoleId = @roleId and ActionId = @actionId ";
            List<object> parameters = new List<object> { roleId, actionId };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
