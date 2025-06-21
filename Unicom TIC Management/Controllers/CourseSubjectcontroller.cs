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
    internal class CourseSubjectcontroller
    {
        public bool CourseSubjectExists(int subjectId, int courseId)
        {
            using (var connection = DB_Connection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM CourseSubject WHERE SubjectID = @subid AND CourseID = @cosid";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@subid", subjectId);
                    cmd.Parameters.AddWithValue("@cosid", courseId);

                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public void Add(CourseSubject courseSubject)
        {
            using(var connection = DB_Connection.GetConnection())
            {
                if (!CourseSubjectExists(courseSubject.SubjectId,courseSubject.CourseId))
                {
                    string Addquery = "INSERT INTO CourseSubject(SubjectID,CourseID) VALUES (@subid,@cosid)";
                    using (var command = new SQLiteCommand(Addquery, connection))
                    {
                        command.Parameters.AddWithValue("@subid", courseSubject.SubjectId);
                        command.Parameters.AddWithValue("@cosid", courseSubject.CourseId);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Course and Subject Linked Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Course and Subject Already in Link","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                
            }
        }
        public static List<CourseSubject> All()
        {
            var list = new List<CourseSubject>();
            using(var  conn = DB_Connection.GetConnection())
            {
                string getall = @"SELECT 
                                cs.SubjectID,
                                cs.CourseID,
                                c.Name AS Coursename,
                                S.Name AS Subjectname
                                FROM CourseSubject cs
                                JOIN Courses c ON cs.CourseID = c.ID
                                JOIN Subjects s ON cs.SubjectID = s.ID";

                using(var command = new SQLiteCommand(getall, conn))
                {
                    using(var reader  = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CourseSubject
                            {
                                SubjectId = Convert.ToInt32(reader["SubjectID"]),
                                CourseId = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["Coursename"].ToString(),
                                SubjectName = reader["Subjectname"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
        public void Delete(int courseid , int subjectid )
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {
                    string query = "DELETE FROM CourseSubject WHERE CourseID = @courseId AND SubjectID = @subjectId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseid);
                        cmd.Parameters.AddWithValue("@subjectId", subjectid);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Mapping not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error while deleting: " + ex.Message);
                }
            }
        }
        public void UpdateCourseSubject(int oldCourseId, int oldSubjectId, int newCourseId, int newSubjectId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {

                    string checkQuery = @"SELECT COUNT(*) FROM CourseSubject 
                                  WHERE CourseID = @newCourseId AND SubjectID = @newSubjectId";

                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@newCourseId", newCourseId);
                        checkCmd.Parameters.AddWithValue("@newSubjectId", newSubjectId);

                        long exists = (long)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("This course-subject combination already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string updateQuery = @"UPDATE CourseSubject 
                                   SET CourseID = @newCourseId, SubjectID = @newSubjectId
                                   WHERE CourseID = @oldCourseId AND SubjectID = @oldSubjectId";

                    using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@newCourseId", newCourseId);
                        updateCmd.Parameters.AddWithValue("@newSubjectId", newSubjectId);
                        updateCmd.Parameters.AddWithValue("@oldCourseId", oldCourseId);
                        updateCmd.Parameters.AddWithValue("@oldSubjectId", oldSubjectId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Mapping updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Update failed. Mapping not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("An error occurred while updating: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
