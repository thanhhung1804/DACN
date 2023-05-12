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

        public List<BillDTO> GetAll()
        {
            List<BillDTO> bills = new List<BillDTO>();
            string query = "select b.BillId, b.CreatedDate, b.Total, b.Status, b.TableId, b.UserId, t.Name as TableName, u.Username from dbo.[Bill] as b, dbo.[Table] as t, dbo.[User] as u where b.TableId = t.TableId and b.UserId = u.UserId";

            database.Connect();
            DataTable dataTable = database.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                BillDTO bill = new BillDTO(row);
                bills.Add(bill);
            }

            database.Disconnect();
            return bills;
        }
    }
}
