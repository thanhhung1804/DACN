using DesktopApp.Common;
using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class ServiceDTO
    {
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServiceStatus Status { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string DisplayName { get; set; }

        public ServiceDTO(DataRow row)
        {
            ServiceId = Guid.Parse(row["ServiceId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            if (int.TryParse(row["Status"].ToString(), out int status))
            {
                Status = (ServiceStatus)status;
            }
            else
            {
                Status = ServiceStatus.Unavailable;
            }
            if (float.TryParse(row["Price"].ToString(), out float price))
            {
                Price = price;
            }
            else
            {
                Price = 0;
            }
            if (row["Image"] == DBNull.Value)
            {
                Image = null;
            }
            else
            {
                Image = (byte[])row["Image"];
            }
            CategoryId = Guid.Parse(row["CategoryId"].ToString());
            CategoryName = row["CategoryName"].ToString();
            DisplayName = string.Format("{0}\n{1}\n{2}", Name, Price, Status.ToString());
            CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
        }
    }
}
