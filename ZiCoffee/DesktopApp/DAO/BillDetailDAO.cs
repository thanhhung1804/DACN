using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DesktopApp.DAO
{
    public class BillDetailDAO
    {
        private SqlServerDatabase database;

        public BillDetailDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<BillDetailDTO> GetBillDetails(Guid billId)
        {
            string query = @"
                select bd.BillId, bd.ServiceId, bd.Quantity, bd.Amount, s.Name as ServiceName, s.Price as ServicePrice 
                from dbo.[BillDetail] as bd, dbo.[Service] as s 
                where bd.ServiceId = s.ServiceId and bd.BillId = @billId";

            List<object> parameters = new List<object> { billId };

            List<BillDetailDTO> billDetails = new List<BillDetailDTO>();
            DataTable dataTable = database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                BillDetailDTO billDetail = new BillDetailDTO(row);
                billDetails.Add(billDetail);
            }
            return billDetails;
        }

        public bool DeleteBillDetails(Guid billId)
        {
            string query = @"delete from dbo.[BillDetail] where BillId = @billId";

            List<object> parameters = new List<object> { billId };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool CreateBillDetails(BillDetailDTO billDetail)
        {
            string query = @"
                insert into dbo.[BillDetail] (BillId, ServiceId, Quantity, Amount) 
                values ( @billId , @serviceId , @quantity , @amount )";

            List<object> parameters = new List<object> { 
                billDetail.BillId,
                billDetail.ServiceId,
                billDetail.Quantity, 
                billDetail.Amount,
            };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
