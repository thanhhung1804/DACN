using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class ServiceDTO
    {
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }

        public ServiceDTO(DataRow row)
        {
            ServiceId = Guid.Parse(row["ServiceId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            if (int.TryParse(row["Status"].ToString(), out int status))
            {
                Status = status;
            }
            else
            {
                Status = 0;
            }
            if (float.TryParse(row["Price"].ToString(), out float price))
            {
                Price = price;
            }
            else
            {
                Price = 0;
            }
            Image = row["Image"].ToString();
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
        }
    }
}
