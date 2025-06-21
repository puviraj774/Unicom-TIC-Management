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
    internal class Studentcontroller
    {
        public bool AddStudent(Student student)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    string addUser = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, 'Student')";
                    using (var cmd = new SQLiteCommand(addUser, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@username", student.Username);
                        cmd.Parameters.AddWithValue("@password", student.Password);
                        cmd.ExecuteNonQuery();
                    }

                    int userId;
                    using (var cmd = new SQLiteCommand("SELECT last_insert_rowid()", conn, trans))
                    {
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string addStudent = "INSERT INTO Students (Name, NIC, CourseID, UserID) VALUES (@name, @nic, @courseId, @userId)";
                    using (var cmd = new SQLiteCommand(addStudent, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@name", student.Name);
                        cmd.Parameters.AddWithValue("@nic", student.NIC);
                        cmd.Parameters.AddWithValue("@courseId", student.CourseId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Student added successfully.", "Success");
                    return true;
                }
                catch (SQLiteException ex)
                {
                    trans.Rollback();
                    if (ex.Message.Contains("Username"))
                        MessageBox.Show("Username already exists.", "Error");
                    else if (ex.Message.Contains("NIC"))
                        MessageBox.Show("NIC already exists.", "Error");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public static List<Student> GetAll()
        {
            var list = new List<Student>();
            using (var conn = DB_Connection.GetConnection())
            {
                string q = @"SELECT s.ID, s.Name, s.NIC, s.CourseID, s.UserID, u.Username, u.Password, c.Name 
                         FROM Students s 
                         JOIN Users u ON s.UserID = u.ID 
                         JOIN Courses c ON s.CourseID = c.ID";

                using (var cmd = new SQLiteCommand(q, conn))
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Student
                        {
                            Id = r.GetInt32(0),
                            Name = r.GetString(1),
                            NIC = r.GetString(2),
                            CourseId = r.GetInt32(3),
                            UserID = r.GetInt32(4),
                            Username = r.GetString(5),
                            Password = r.GetString(6),
                            Coursename = r.GetString(7)
                        });
                    }
                }
            }
            return list;
        }
        public static List<Student> GetIdAndNameOnly()
        {
            var list = new List<Student>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"SELECT ID, Name FROM Students";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }




        public bool DeleteStudent(int studentId)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    int userId = -1;
                    string getUserId = "SELECT UserID FROM Students WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(getUserId, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    using (var cmd = new SQLiteCommand("DELETE FROM Students WHERE ID = @id", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", studentId);
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SQLiteCommand("DELETE FROM Users WHERE ID = @id", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Delete failed: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateStudent(Student student)
        {
            using (var conn = DB_Connection.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    string q1 = "UPDATE Students SET Name = @name, NIC = @nic, CourseID = @courseId WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(q1, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@name", student.Name);
                        cmd.Parameters.AddWithValue("@nic", student.NIC);
                        cmd.Parameters.AddWithValue("@courseId", student.CourseId);
                        cmd.Parameters.AddWithValue("@id", student.Id);
                        cmd.ExecuteNonQuery();
                    }

                    string q2 = "UPDATE Users SET Username = @username, Password = @password WHERE ID = @userId";
                    using (var cmd = new SQLiteCommand(q2, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@username", student.Username);
                        cmd.Parameters.AddWithValue("@password", student.Password);
                        cmd.Parameters.AddWithValue("@userId", student.UserID);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Student updated successfully.");
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Update failed: " + ex.Message);
                    return false;
                }
            }
        }
        public int GetStudentIdByUserId(int userId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID FROM Students WHERE UserID = @userId";
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
