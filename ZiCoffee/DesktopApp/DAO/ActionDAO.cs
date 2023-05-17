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
    public class ActionDAO
    {
        private SqlServerDatabase database;

        public ActionDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<ActionDTO> GetAll() 
        {
            string query = @"select * from dbo.[Action] order by Name";
            List<ActionDTO> actions = new List<ActionDTO>();
            DataTable dataTable = database.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                ActionDTO action = new ActionDTO(row);
                actions.Add(action);
            }
            return actions;
        }
    }
}
