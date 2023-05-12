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

        public List<TableDTO> GetAll()
        {
            List<TableDTO> tables = new List<TableDTO>();
            string query = "select * from dbo.[Table]";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                TableDTO table = new TableDTO(row);
                tables.Add(table);
            }

            database.Disconnect();
            return tables;
        }
    }
}
