using MusicApplication.Data;
using MusicApplication.Services.contracts;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MusicApplication.Services
{
    public class UserService : IUserService
    {
        private string connectionString;
        private SqlDataAdapter adapter;

        public UserService(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public User GetUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spGetUserByUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User(reader);

                            // TODO password hashing
                            if (user != null && user.Password == password)
                            {
                                return user;
                            }
                        }
                    }
                }
            }
            return null;
        }


        public User UpdateUser(int id, User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spUpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();

                    command.ExecuteNonQuery();

                    return user;
                }
            }
        }


        public User CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spCreateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();

                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = new SqlCommand("spGetUserByUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", user.Username);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userToReturn = new User(reader);
                            if (user != null)
                            {
                                return user;
                            }
                        }
                    }
                }

                return null;
            }
        }


        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
