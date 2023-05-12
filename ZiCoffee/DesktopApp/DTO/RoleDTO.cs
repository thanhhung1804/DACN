using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RoleDTO(DataRow row) 
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
