using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class AreaDTO
    {
        public Guid AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AreaDTO(DataRow row)
        {
            AreaId = Guid.Parse(row["AreaId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
        }
    }
}
