using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DesktopApp.DAO
{
    public class AreaDAO
    {
        private SqlServerDatabase database;

        public AreaDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<AreaDTO> GetAll(bool ascSortByName = true)
        {
            string query = "select * from dbo.[Area]";
            if (ascSortByName)
            {
                query += " order by Name";
            }
            else
            {
                query += " order by Name desc";
            }

            List<AreaDTO> areas = new List<AreaDTO>();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                AreaDTO area = new AreaDTO(row);
                areas.Add(area);
            }
            return areas;
        }

        public bool Create(string name, string description = null)
        {
            string query = "insert into dbo.[Area] (AreaId, Name, Description) values ( @areaId , @name , @description )";

            Guid newAreaId = Guid.NewGuid();
            List<object> parameters = new List<object>() { newAreaId, name, description };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(Guid areaId, string name, string description = null)
        {
            string query = "update dbo.[Area] set Name = @name , Description = @description where AreaId = @areaId";

            List<object> parameters = new List<object>() { name, description, areaId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid areaId)
        {
            string query = "delete from dbo.[Area] where AreaId = @areaId";

            List<object> parameters = new List<object>() { areaId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
