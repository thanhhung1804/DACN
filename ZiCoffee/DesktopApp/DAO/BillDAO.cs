using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DAO
{
    public class BillDAO
    {
        private SqlServerDatabase database;

        public BillDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public Tuple<List<BillDTO>, float> GetRevenue(DateTime startTime, DateTime endTime, string tableName, string username)
        {
            List<BillDTO> bills = new List<BillDTO>();
            string query = @"
                select b.BillId, b.CreatedDate, b.Total, b.Status, b.TableId, b.UserId, t.Name as TableName, u.Username 
                from dbo.[Bill] as b, dbo.[Table] as t, dbo.[User] as u 
                where b.TableId = t.TableId 
                    and b.UserId = u.UserId 
                    and b.CreatedDate between @startTime and @endTime";
            List<object> parameters = new List<object> { startTime, endTime };

            if (!string.IsNullOrEmpty(tableName))
            {
                query += " and upper(t.Name) like upper( @tableName )";
                tableName = string.Format("%{0}%", tableName);
                parameters.Add(tableName);
            }

            if (!string.IsNullOrEmpty(username))
            {
                query += " and upper(u.Username) like upper( @username )";
                username = string.Format("%{0}%", username);
                parameters.Add(username);
            }

            DataTable dataTable = database.ExecuteQuery(query, parameters);
            float totalRevenue = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                BillDTO bill = new BillDTO(row);
                bills.Add(bill);
                if (float.TryParse(row["Total"].ToString(), out float total))
                {
                    totalRevenue += total;
                }
            }
            return new Tuple<List<BillDTO>, float>(bills, totalRevenue);
        }
    }
}
