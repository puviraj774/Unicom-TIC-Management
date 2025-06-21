using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Models;
using Unicom_TIC_Management.Repos;

namespace Unicom_TIC_Management.Controllers
{
    internal class Staffcontroller
    {
        public void AddStaff(Staff staff)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string addUser = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, 'Staff')";
                    using (var cmd = new SQLiteCommand(addUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", staff.Username);
                        cmd.Parameters.AddWithValue("@password", staff.Password);
                        cmd.ExecuteNonQuery();
                    }

                    int userId;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", conn, transaction))
                    {
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string addStaff = "INSERT INTO Staff (Name, NIC, UserID) VALUES (@name, @nic, @userid)";
                    using (var cmd = new SQLiteCommand(addStaff, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", staff.Name);
                        cmd.Parameters.AddWithValue("@nic", staff.NIC);
                        cmd.Parameters.AddWithValue("@userid", userId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SQLiteException ex)
                {
                    transaction.Rollback();
                    if (ex.Message.Contains("Username"))
                        MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.Message.Contains("NIC"))
                        MessageBox.Show("NIC already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }

        public void UpdateStaff(Staff staff)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string updateStaff = "UPDATE Staff SET Name = @name, NIC = @nic WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(updateStaff, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", staff.Name);
                        cmd.Parameters.AddWithValue("@nic", staff.NIC);
                        cmd.Parameters.AddWithValue("@id", staff.Id);
                        cmd.ExecuteNonQuery();
                    }

                    string updateUser = "UPDATE Users SET Username = @username, Password = @password WHERE ID = @userid";
                    using (var cmd = new SQLiteCommand(updateUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", staff.Username);
                        cmd.Parameters.AddWithValue("@password", staff.Password);
                        cmd.Parameters.AddWithValue("@userid", staff.UserID);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Staff updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SQLiteException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool DeleteStaff(int staffId)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    int userId = -1;

                    string getUserIdQuery = "SELECT UserID FROM Staff WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(getUserIdQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", staffId);
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Staff not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaction.Rollback();
                            return false;
                        }
                        userId = Convert.ToInt32(result);
                    }
                    string deleteStaffQuery = "DELETE FROM Staff WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(deleteStaffQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", staffId);
                        cmd.ExecuteNonQuery();
                    }
                    if (userId != -1)
                    {
                        string deleteUserQuery = "DELETE FROM Users WHERE ID = @id";
                        using (var cmd = new SQLiteCommand(deleteUserQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Staff deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (SQLiteException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error while deleting staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public static List<Staff> AllStaff()
        {
            var list = new List<Staff>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"SELECT s.ID, s.Name, s.NIC, u.ID as UserID, u.Username, u.Password
                                 FROM Staff s
                                 JOIN Users u ON s.UserID = u.ID
                                 ORDER BY s.Name";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Staff
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            NIC = reader.GetString(2),
                            UserID = reader.GetInt32(3),
                            Username = reader.GetString(4),
                            Password = reader.GetString(5)
                        });
                    }
                }
            }
            return list;
        }
        public int GetStaffIdByUserId(int userId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID FROM Staff WHERE UserID = @userId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

    }

}
