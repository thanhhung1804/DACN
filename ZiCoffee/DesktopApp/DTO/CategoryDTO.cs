using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class CategoryDTO
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public CategoryDTO(DataRow row)
        {
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
        }

        public CategoryDTO(string name)
        {
            CategoryId = Guid.Empty;
            Name = name;
            Description = null;
            CreatedDate = DateTime.Now;
        }
    }
}
