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
    public class AreaDAO
    {
        private SqlServerDatabase database;

        public AreaDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<AreaDTO> GetAll()
        {
            List<AreaDTO> areas = new List<AreaDTO>();
            string query = "select * from dbo.[Area]";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                AreaDTO area = new AreaDTO(row);
                areas.Add(area);
            }

            database.Disconnect();
            return areas;
        }
    }
}
