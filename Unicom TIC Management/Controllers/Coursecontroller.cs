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
    internal class Coursecontroller
    {
        public void Addcourse(Course course)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO Courses (Name) VALUES (@name)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", course.Name);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Course added successfully.");
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Constraint)
                    {
                        MessageBox.Show("Course already exists.");
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: " + ex.Message);
                }
            }
        }


        public void DeleteCourse(int CourseId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM Courses WHERE ID = @Id", conn);
                command.Parameters.AddWithValue("@Id", CourseId);
                int total = command.ExecuteNonQuery();

                if (total > 0)
                {
                    DeleteCourseFromCourseSubject(CourseId);
                    MessageBox.Show("Course Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void DeleteCourseFromCourseSubject(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {
                    var command = new SQLiteCommand("DELETE FROM CourseSubject WHERE CourseID = @Id", conn);
                    command.Parameters.AddWithValue("@Id", id);
                    int total = command.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error Occurred"+ex.Message);
                }
            }
        }



        public static List<Course> GetCourseList()
        {
            var courses = new List<Course>();

            using (var conn = DB_Connection.GetConnection())
            {
                string coursequery = "SELECT * FROM Courses";

                using (var cmd = new SQLiteCommand(coursequery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            };
                            courses.Add(course);
                        }
                    }
                }

            }
            return courses;
        }

        public Course GetCourseById(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Courses WHERE ID = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Course
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
    }
}
