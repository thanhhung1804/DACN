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
    public class TableDAO
    {
        private SqlServerDatabase database;

        public TableDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<TableDTO> GetAll(
            Guid areaId, 
            string keyword = null, 
            TableStatus status = TableStatus.All,
            bool ascSortByName = true)
        {
            string query = @"
                select t.TableId, t.Name, t.Description, t.Status, t.AreaId, a.Name as AreaName 
                from dbo.[Table] as t, dbo.[Area] as a 
                where t.AreaId = a.AreaId";

            List<object> parameters = new List<object>();
            if (!string.IsNullOrEmpty(keyword))
            {
                query += @" and ( 
                        upper(t.Name) like upper( @keyword1 ) 
                        or upper(t.Description) like upper( @keyword2 ) 
                        or upper( a.Name ) like upper( @keyword3 )
                    )";
                keyword = string.Format("%{0}%", keyword);
                for (int i = 0; i < 3; i++)
                {
                    parameters.Add(keyword);
                }
            }
            if (areaId != null && areaId != Guid.Empty)
            {
                query += " and t.AreaId = @areaId";
                parameters.Add(areaId);
            }
            if (status != TableStatus.All)
            {
                query += " and t.Status = @status";
                parameters.Add(status);
            }
            if (ascSortByName)
            {
                query += " order by t.Name";
            }
            else
            {
                query += " order by t.Name desc";
            }

            List<TableDTO> tables = new List<TableDTO>();
            DataTable dataTable = database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                TableDTO table = new TableDTO(row);
                tables.Add(table);
            }
            return tables;
        }

        public bool Create(
            string name, 
            Guid areaId, 
            TableStatus status = TableStatus.Ready, 
            string description = null)
        {
            string query = @"
                insert into dbo.[Table] (TableId, Name, Description, Status, AreaId) 
                values ( @tableId , @name , @description , @status , @areaId )";

            Guid newTableId = Guid.NewGuid();
            List<object> parameters = new List<object> { newTableId, name, description, status, areaId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(
            Guid tableId,
            string name,
            Guid areaId,
            TableStatus status = TableStatus.Ready,
            string description = null)
        {
            string query = @"
                update dbo.[Table] 
                set Name = @name , Description = @description , Status = @status , AreaId = @areaId  
                where TableId = @tableId";

            List<object> parameters = new List<object> { name, description, status, areaId, tableId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid tableId)
        {
            string query = @"delete from dbo.[Table] where TableId = @tableId";

            List<object> parameters = new List<object> { tableId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool ChangeStatus(Guid tableId, TableStatus status)
        {
            string query = @"update dbo.[Table] set Status = @status where TableId = @tableId";

            List<object> parameters = new List<object> { status, tableId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
