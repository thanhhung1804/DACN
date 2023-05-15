using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class RoleActionDTO
    {
        public Guid RoleId { get; set; }
        public Guid ActionId { get; set; }

        public RoleActionDTO(DataRow row) 
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            ActionId = Guid.Parse(row["ActionId"].ToString());
        }
    }
}
