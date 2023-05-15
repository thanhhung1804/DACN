using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class ActionDTO
    {
        public Guid ActionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ActionDTO(DataRow row) 
        { 
            ActionId = Guid.Parse(row["ActionId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
