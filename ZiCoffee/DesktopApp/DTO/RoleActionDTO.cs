using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class RoleActionDTO
    {
        public Guid RoleId { get; set; }
        public Guid ActionId { get; set; }

        public string ActionName { get; set; }

        public RoleActionDTO(DataRow row) 
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            ActionId = Guid.Parse(row["ActionId"].ToString());
            ActionName = row["ActionName"].ToString();
        }
    }
}
