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
    internal class Lecturercontroller
    {
        public void AddUser(Lecturer lecturer)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string addUser = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                    using (var cmd = new SQLiteCommand(addUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", lecturer.Username);
                        cmd.Parameters.AddWithValue("@password", lecturer.Password);
                        cmd.Parameters.AddWithValue("@role", "Lecturer");
                        cmd.ExecuteNonQuery();
                    }
                    int lastId;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", conn, transaction))
                    {
                        lastId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    string addLecturer = "INSERT INTO Lecturers (Name, UserID, NIC) VALUES (@name, @userid, @nic)";
                    using (var cmd = new SQLiteCommand(addLecturer, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", lecturer.Name);
                        cmd.Parameters.AddWithValue("@userid", lastId);
                        cmd.Parameters.AddWithValue("@nic", lecturer.NIC);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    MessageBox.Show("Lecturer Added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SQLiteException ex)
                {
                    transaction.Rollback();
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        if (ex.Message.Contains("Username"))
                            MessageBox.Show("Username Already Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (ex.Message.Contains("NIC"))
                            MessageBox.Show("NIC Already Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Constraint error: " + ex.Message);
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }

        public bool DeleteLecturer(int lecturerId)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    int userId = -1;
                    string getUserIdQuery = "SELECT UserID FROM Lecturers WHERE ID = @id";
                    using (var getUserCmd = new SQLiteCommand(getUserIdQuery, conn, transaction))
                    {
                        getUserCmd.Parameters.AddWithValue("@id", lecturerId);
                        var result = getUserCmd.ExecuteScalar();
                        if (result == null)
                        {
                            transaction.Rollback();
                            return false; 
                        }
                        userId = Convert.ToInt32(result);
                    }
                    string deleteSubjectsQuery = "DELETE FROM LecturerSubjects WHERE LecturerID = @id";
                    using (var cmd = new SQLiteCommand(deleteSubjectsQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", lecturerId);
                        cmd.ExecuteNonQuery();
                    }
                    string deleteLecturerQuery = "DELETE FROM Lecturers WHERE ID = @id";
                    using (var deleteLecturerCmd = new SQLiteCommand(deleteLecturerQuery, conn, transaction))
                    {
                        deleteLecturerCmd.Parameters.AddWithValue("@id", lecturerId);
                        int rowsAffected = deleteLecturerCmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    string deleteUserQuery = "DELETE FROM Users WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(deleteUserQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (SQLiteException)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        


        public void UpdateLecturer(Lecturer lecturer)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string updateLecturer = "UPDATE Lecturers SET Name = @name, NIC = @nic WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(updateLecturer, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", lecturer.Name);
                        cmd.Parameters.AddWithValue("@nic", lecturer.NIC);
                        cmd.Parameters.AddWithValue("@id", lecturer.Id);
                        cmd.ExecuteNonQuery();
                    }
                    string updateUser = "UPDATE Users SET Username = @username, Password = @password WHERE ID = (SELECT UserID FROM Lecturers WHERE ID = @id)";
                    using (var cmd = new SQLiteCommand(updateUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", lecturer.Username);
                        cmd.Parameters.AddWithValue("@password", lecturer.Password);
                        cmd.Parameters.AddWithValue("@id", lecturer.Id);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (SQLiteException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        public static List<Lecturer> AllLecturer()
        {
            var lecturers = new List<Lecturer>();

            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"
                                SELECT 
                                    l.ID, 
                                    l.Name, 
                                    l.NIC, 
                                    u.Username, 
                                    u.Password 
                                FROM Lecturers l
                                JOIN Users u ON l.UserID = u.ID
                                ORDER BY l.Name";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lecturer lecturer = new Lecturer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            NIC = reader.GetString(2),
                            Username = reader.GetString(3),
                            Password = reader.GetString(4)
                        };

                        lecturers.Add(lecturer);
                    }
                }
            }

            return lecturers;
        }
        public int GetLecturerIdByUserId(int userId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID FROM Lecturers WHERE UserID = @userId";
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
