using DesktopApp.Common;
using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class TableDTO
    {
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TableStatus Status { get; set; }
        public Guid AreaId { get; set; }
        public string AreaName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string DisplayName { get; set; }

        public TableDTO(DataRow row)
        {
            TableId = Guid.Parse(row["TableId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            if (int.TryParse(row["Status"].ToString(), out int status))
            {
                Status = (TableStatus)status;
            }
            else
            { 
                Status = TableStatus.Ready;
            }
            AreaId = Guid.Parse(row["AreaId"].ToString());
            AreaName = row["AreaName"].ToString();
            DisplayName = string.Format("{0}\n{1}", Name, Status.ToString());
            CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
        }
    }
}
