using DesktopApp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesktopApp.Model
{
    public class BillDTO
    {
        public Guid BillId { get; set; }
        public DateTime CreatedDate { get; set; }
        public float Total { get; set; }
        public BillStatus Status { get; set; }
        public Guid TableId { get; set; }
        public Guid UserId { get; set; }

        public string TableName { get; set; }
        public string Username { get; set; }

        public BillDTO(DataRow row) 
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
            if (float.TryParse(row["Total"].ToString(), out float total))
            {
                Total = total;
            }
            else
            {
                Total = 0;
            }
            if (int.TryParse(row["Status"].ToString(), out int status))
            {
                Status = (BillStatus)status;
            }
            else
            {
                Status = BillStatus.UnPaid;
            }
            TableId = Guid.Parse(row["TableId"].ToString());
            UserId = Guid.Parse(row["UserId"].ToString());
            TableName = row["TableName"].ToString();
            Username = row["Username"].ToString();
        }
    }
}
