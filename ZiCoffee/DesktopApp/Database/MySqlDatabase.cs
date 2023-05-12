using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DesktopApp.Database
{
    public class MySqlDatabase : Database
    {
        public MySqlDatabase(string connectionString) : base(connectionString)
        {
        }

        public override DataTable ExecuteQuery(string query)
        {
            //Build command object
            var command = connection.CreateCommand();
            command.CommandText = query;
            //Build adapter object as object allowed 2 different things work togeter
            var adapter = new MySqlDataAdapter(command as MySqlCommand);
            //Build an empty datatable
            var dataTable = new DataTable();
            //Fill data into empty datatable 
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
