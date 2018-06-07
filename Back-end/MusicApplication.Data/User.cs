using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MusicApplication.Data
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string Rolename { get; set; }

        public User()
        {
        }

        public User(IDataReader reader)
        {
            CastFromReader(reader);
        }

        public void CastFromReader(IDataReader reader)
        {
            if ((Convert.ToString(reader["Username"])) != null && (Convert.ToString(reader["Username"])) != string.Empty)
            {
                try
                {
                    this.UserId = Convert.ToInt32(reader["UserId"]);
                    this.Username = (string)reader["Username"];
                    this.Password = (string)reader["Password"];
                    this.RoleId = Convert.ToInt32(reader["RoleId"]);
                    this.Rolename = (string)reader["Rolename"];
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}
