using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Database
{
    public class SqlServerDatabase
    {
        //properties
        protected string connectionString;
        protected SqlConnection connection;

        //constructor
        public SqlServerDatabase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //functions

        /// <summary>
        /// Init connection and open it
        /// </summary>
        public void Connect()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /// <summary>
        /// Close connection and release it
        /// </summary>
        public void Disconnect()
        {
            connection.Close();
            connection.Dispose();
        }

        /// <summary>
        /// Execute SELECT query commands
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Result of query as DataTable</returns>
        public bool IsConnected()
        {
            return connection != null && connection.State == ConnectionState.Open;
        }

        /// <summary>
        /// Execute SELECT query commands
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>Result of query as DataTable</returns>
        public DataTable ExecuteQuery(string query, List<object> parameters = null)
        {
            //Init and open connection to database
            Connect();
            //Build command object
            SqlCommand command = new SqlCommand(query, connection);
            //Transfer params to command
            if (parameters != null)
            {
                string[] splitedQuery = query.Split(' ');
                int i = 0;
                foreach (string item in splitedQuery)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            string a = command.CommandText;
            //Build adapter object as object allowed 2 different things work togeter
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            //Build an empty datatable
            DataTable dataTable = new DataTable();
            //Fill data into empty datatable 
            adapter.Fill(dataTable);
            //Close and release connection
            Disconnect();
            return dataTable;
        }

        /// <summary>
        /// Execute INSERT, UPDATE, DELETE commands
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>True if execute successfully else False</returns>
        public bool ExecuteNoneQuery(string query, List<object> parameters = null)
        {
            //Init and open connection to database
            Connect();
            //Build command object
            SqlCommand command = new SqlCommand(query, connection);
            //Transfer params to command
            if (parameters != null)
            {
                string[] splitedQuery = query.Split(' ');
                int i = 0;
                foreach (string item in splitedQuery)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            //Check number of successfully lines
            bool executeResult = command.ExecuteNonQuery() > 0;
            //Close and release connection
            Disconnect();
            return executeResult;
        }

        /// <summary>
        /// Execute SELECT query commands, but not return as a DataTable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>An object, this object can be anything</returns>
        public object ExecuteScalar(string query, List<object> parameters = null)
        {
            //Init and open connection to database
            Connect();
            //Build command object
            SqlCommand command = new SqlCommand(query, connection);
            //Transfer params to command
            if (parameters != null)
            {
                string[] splitedQuery = query.Split(' ');
                int i = 0;
                foreach (string item in splitedQuery)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            //Execute command and get data object
            object data = command.ExecuteScalar();
            //Close and release connection
            Disconnect();
            return data;
        }
    }
}


