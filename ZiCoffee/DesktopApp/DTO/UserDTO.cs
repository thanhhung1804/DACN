using DesktopApp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string CitizenId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public UserDTO(DataRow row) 
        {
            UserId = Guid.Parse(row["UserId"].ToString());
            Username = row["Username"].ToString();
            Password = row["Password"].ToString();
            if (row["Avatar"] == DBNull.Value)
            {
                Avatar = null;
            }
            else
            {
                Avatar = (byte[])row["Avatar"];
            }
            Name = row["Name"].ToString();
            if (int.TryParse(row["Gender"].ToString(), out int gender))
            {
                Gender = (Gender)gender;
            }
            else
            {
                Gender = Gender.Male;
            }
            Birthday = DateTime.Parse(row["Birthday"].ToString());
            Address = row["Address"].ToString();
            CitizenId = row["CitizenId"].ToString();
            Phone = row["Phone"].ToString();
            Email = row["Email"].ToString();
            RoleId = Guid.Parse(row["RoleId"].ToString());
            RoleName = row["RoleName"].ToString();
        }
    }
}
