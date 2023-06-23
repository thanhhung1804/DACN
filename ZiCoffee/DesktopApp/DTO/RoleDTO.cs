using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public RoleDTO(DataRow row) 
        {
            RoleId = Guid.Parse(row["RoleId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
        }
    }
}
