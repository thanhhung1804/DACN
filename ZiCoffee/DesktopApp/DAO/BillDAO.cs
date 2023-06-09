using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DesktopApp.DAO
{
    public class BillDAO
    {
        private SqlServerDatabase database;

        public BillDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public Tuple<List<BillDTO>, float> GetRevenue(DateTime startTime, DateTime endTime, string tableName = null, string username = null)
        {
            string query = @"
                select b.BillId, b.CreatedDate, b.Total, b.Status, b.TableId, b.UserId, t.Name as TableName, u.Username 
                from dbo.[Bill] as b, dbo.[Table] as t, dbo.[User] as u 
                where b.TableId = t.TableId 
                    and b.UserId = u.UserId 
                    and b.CreatedDate between @startTime and @endTime 
                    and b.Status = @status";

            List<object> parameters = new List<object> { startTime, endTime, BillStatus.Paid };
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
            query += " order by b.CreatedDate";

            List<BillDTO> bills = new List<BillDTO>();
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

        public BillDTO GetUnpaidBillByTable(Guid tableId)
        {
            string query = @"
                select b.BillId, b.CreatedDate, b.Total, b.Status, b.TableId, b.UserId, t.Name as TableName, u.Username 
                from dbo.[Bill] as b, dbo.[Table] as t, dbo.[User] as u 
                where b.TableId = t.TableId 
                    and b.UserId = u.UserId 
                    and b.TableId = @tableId 
                    and b.Status = @status";

            List<object> parameters = new List<object> { tableId, BillStatus.UnPaid };

            DataTable dataTable = database.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count <= 0)
            {
                return null;
            }
            BillDTO bill = new BillDTO(dataTable.Rows[0]);
            return bill;
        }

        public Tuple<bool, Guid> Create(Guid tableId, Guid userId)
        {
            string query = @"
                insert into dbo.[Bill] (BillId, CreatedDate, Total, Status, TableId, UserId) 
                values ( @billId , @createdDate , @total , @status , @tableId , @userId )";

            Guid newBillId = Guid.NewGuid();
            DateTime createdDate = DateTime.Now;
            float total = 0;
            BillStatus status = BillStatus.UnPaid;

            List<object> parameters = new List<object> { newBillId, createdDate, total, status, tableId, userId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return Tuple.Create(result, newBillId);
        }

        public bool Delete(Guid billId)
        {
            string query = @"delete from dbo.[Bill] where BillId = @billId";

            List<object> parameters = new List<object> { billId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool ChangeStatus(Guid billId, BillStatus status)
        {
            string query = @"update dbo.[Bill] set Status = @status where BillId = @billId";

            List<object> parameters = new List<object> { status, billId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool UpdateTotal(Guid billId, float total)
        {
            string query = @"update dbo.[Bill] set Total = @total where BillId = @billId";

            List<object> parameters = new List<object> { total, billId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool UpdateTableId(Guid billId, Guid tableId)
        {
            string query = @"update dbo.[Bill] set TableId = @tableId where BillId = @billId";

            List<object> parameters = new List<object> { tableId, billId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
