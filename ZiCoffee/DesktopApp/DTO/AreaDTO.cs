using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class AreaDTO
    {
        public Guid AreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public AreaDTO(DataRow row)
        {
            AreaId = Guid.Parse(row["AreaId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
        }

        public AreaDTO(string name)
        {
            AreaId = Guid.Empty;
            Name = name;
            Description = null;
            CreatedDate = DateTime.Now;
        }
    }
}
