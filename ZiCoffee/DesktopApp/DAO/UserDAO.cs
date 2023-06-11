using DesktopApp.Common;
using DesktopApp.Database;
using DesktopApp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesktopApp.DAO
{
    public class UserDAO
    {
        private SqlServerDatabase database;

        public UserDAO()
        {
            database = new SqlServerDatabase(Constants.CONNECTION_STRING);
        }

        public List<UserDTO> GetAll(string keyword = null, Gender gender = Gender.All)
        {
            string query = @"
                select u.UserId, u.Username, u.Password, u.Avatar, u.Name, u.Gender, u.Birthday, 
                    u.Address, u.CitizenId, u.Phone, u.Email, u.RoleId, r.Name as RoleName 
                from dbo.[User] as u, dbo.[Role] as r 
                where u.RoleId = r.RoleId";

            List<object> parameters = new List<object> { };
            if (!string.IsNullOrEmpty(keyword))
            {
                query += @" and (
                        upper(u.Username) like upper( @keyword1 ) 
                        or upper(u.Name) like upper( @keyword2 ) 
                        or upper(u.Address) like upper( @keyword3 ) 
                        or upper(u.CitizenId) like upper( @keyword4 ) 
                        or upper(u.Phone) like upper( @keyword5 ) 
                        or upper(u.Email) like upper( @keyword6 ) 
                        or upper(r.Name) like upper( @keyword7 ) 
                    )";
                keyword = string.Format("%{0}%", keyword);
                for (int i = 0; i < 7; i++)
                {
                    parameters.Add(keyword);
                }
            }
            if (gender != Gender.All)
            {
                query += " and u.Gender = @gender";
                parameters.Add(gender);
            }

            List<UserDTO> users = new List<UserDTO>();
            DataTable dataTable = database.ExecuteQuery(query, parameters);
            foreach (DataRow row in dataTable.Rows)
            {
                UserDTO user = new UserDTO(row);
                users.Add(user);
            }
            return users;
        }

        public bool Create(
            string username, string name, string address, string citizenId, string phone,
            DateTime birthday, Guid roleId, string email = null, Gender gender = Gender.Male, 
            byte[] avatar = null)
        {
            string query = @"
                insert into dbo.[User] (
                    UserId, Username, Password, Name, Address, CitizenId, Phone, 
                    Birthday, RoleId, Email, Gender, Avatar
                ) values ( 
                    @userId , @username , @password , @name , @address , @citizenId , @phone , 
                    @birthday , @roleId , @email , @gender , @avatar 
                )";

            Guid userId = Guid.NewGuid();
            string defaultPassword = "P@$$w0rd";
            DateTime birthdayDateOnly = new DateTime(birthday.Year, birthday.Month, birthday.Day);
            if (avatar is null)
            {
                avatar = new byte[0];
            }
            List<object> parameters = new List<object>
            {
                userId, username, defaultPassword, name, address, citizenId, phone,
                birthdayDateOnly, roleId, email, gender, avatar
            };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Delete(Guid userId)
        {
            string query = @"delete from dbo.[User] where UserId = @userId";
            List<object> parameters = new List<object> { userId };
            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public bool Update(
            Guid userId, string name, string address, string citizenId, string phone,
            DateTime birthday, Guid roleId, string email = null, Gender gender = Gender.Male,
            byte[] avatar = null)
        {
            string query = @"
                update dbo.[User] set 
                    Name = @name , 
                    Address = @address , 
                    CitizenId = @citizenId , 
                    Phone = @phone , 
                    Birthday = @birthday , 
                    RoleId = @roleId , 
                    Email = @email , 
                    Gender = @gender ,
                    Avatar = @avatar 
                where UserId = @userId";

            DateTime birthdayDateOnly = new DateTime(birthday.Year, birthday.Month, birthday.Day);
            if (avatar is null)
            {
                avatar = new byte[0];
            }
            List<object> parameters = new List<object>
            {
                name, address, citizenId, phone, birthdayDateOnly, roleId, email, gender, avatar, userId
            };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }

        public UserDTO GetUser(string username, string password = null)
        {
            string query = @"
                select u.UserId, u.Username, u.Password, u.Avatar, u.Name, u.Gender, u.Birthday, 
                    u.Address, u.CitizenId, u.Phone, u.Email, u.RoleId, r.Name as RoleName 
                from dbo.[User] as u, dbo.[Role] as r 
                where u.RoleId = r.RoleId and u.Username = @username";

            List<object> parameters = new List<object> { username };

            if (password != null)
            {
                query += " and u.Password = @password";
                parameters.Add(password);
            }

            DataTable dataTable = database.ExecuteQuery(query, parameters);
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }
            UserDTO user = new UserDTO(dataTable.Rows[0]);
            return user;
        }

        public bool SetPassword(Guid userId, string password)
        {
            string query = @"update dbo.[User] set Password = @password where UserId = @userId";

            List<object> parameters = new List<object> { password, userId };

            bool result = database.ExecuteNoneQuery(query, parameters);
            return result;
        }
    }
}
