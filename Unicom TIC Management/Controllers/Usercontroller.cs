using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Models;
using Unicom_TIC_Management.Repos;

namespace Unicom_TIC_Management.Controllers
{
    internal class Usercontroller
    {
        public void AddAdmin(User user)
        {
            using (var connection = DB_Connection.GetConnection())
            {
                string UserQuery = "INSERT INTO Users(Username,Password,Role) VALUES (@username,@password,@role)";

                SQLiteCommand command = new SQLiteCommand(UserQuery, connection);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@role", "Admin");
                command.ExecuteNonQuery();

                MessageBox.Show("Admin created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public User FindUsernamePassword(string username, string password)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"SELECT ID, Username, Role FROM Users WHERE Username = @username AND Password = @password";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Username = reader["Username"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }


        public static User GetUserById(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID, Username, Role FROM Users WHERE ID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Username = reader["Username"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
        public static void ChangePassword(int userId, string newPassword)
        {
            using (var connection = DB_Connection.GetConnection())
            {
                string query = "UPDATE Users SET Password = @password WHERE ID = @id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@password", newPassword);
                    command.Parameters.AddWithValue("@id", userId);
                    command.ExecuteNonQuery();
                }
            }           
        }
    }
}
