using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;

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
            string query = "select * from dbo.[Role]";

            List<RoleDTO> roles = new List<RoleDTO>();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                RoleDTO role = new RoleDTO(row);
                roles.Add(role);
            }
            return roles;
        }

        public Tuple<bool, Guid> Create(string name, string description = null)
        {
            string query = @"insert into dbo.[Role] (RoleId, Name, Description) values ( @roleId , @name , @description )";
            Guid roleId = Guid.NewGuid();
            List<object> parameters = new List<object> { roleId, name, description };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return Tuple.Create(result, roleId);
        }

        public bool Delete(Guid roleId)
        {
            string query = @"delete from dbo.[Role] where RoleId = @roleId";
            List<object> parameters = new List<object> { roleId };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(Guid roleId, string name, string description = null)
        {
            string query = @"update dbo.[Role] set Name = @name , Description = @description where RoleId = @roleId";
            List<object> parameters = new List<object> { name, description, roleId };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool IsExistName(string name)
        {
            string query = @"select * from dbo.[Role] where Name = @name";
            List<object> parameters = new List<object> { name };
            DataTable result = database.ExecuteQuery(query, parameters);
            if (result.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
