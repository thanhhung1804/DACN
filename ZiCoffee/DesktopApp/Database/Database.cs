using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Database
{
    public abstract class Database : IDatabase
    {
        //properties
        protected string connectionString;
        protected IDbConnection connection;

        //constructor
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //function
        public virtual void Connect()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public virtual void Disconnect()
        {
            connection.Close();
            connection.Dispose();
        }

        public virtual DataTable ExecuteQuery(string query)
        {
            //Build command object
            var command = connection.CreateCommand();
            command.CommandText = query;
            //Build adapter object as object allowed 2 different things work togeter
            var adapter = new SqlDataAdapter(command as SqlCommand);
            //Build an empty datatable
            var dataTable = new DataTable();
            //Fill data into empty datatable 
            adapter.Fill(dataTable);
            return dataTable;
        }

        public virtual bool IsConnected()
        {
            return connection != null && connection.State == ConnectionState.Open;
        }
    }
}


