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
    internal class Subjectcontroller
    {
        public void Addsubject(Subject subject)
        {
            try
            {
                using (var conn = DB_Connection.GetConnection())
                {
                    string AddQuery = "INSERT INTO Subjects (Name) VALUES (@name)";
                    using (var cmd = new SQLiteCommand(AddQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.Name);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Subject Added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SQLiteException ex) 
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint)
                {
                    MessageBox.Show("Subject already exists.");
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }

        public void DeletesubjectFromSubjects(int id)
        {
            using (var db = DB_Connection.GetConnection())
            {
                string delQuery = "DELETE FROM Subjects WHERE ID = @id";
                using (var cmd = new SQLiteCommand(delQuery, db))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int totoal =cmd.ExecuteNonQuery();

                    if (totoal > 0)
                    {
                        DeleteSubjectFromCourseSubject(id);
                        DeleteSubjectFromLecturerSubjects(id);
                        MessageBox.Show("Subject Deleted Successfully","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Subject Not Found!","Error",MessageBoxButtons.OK);
                    }
                }        
            }              
        }
        public void DeleteSubjectFromCourseSubject(int id)
        {
            using(var  db = DB_Connection.GetConnection())
            {
                string delquery = "DELETE FROM CourseSubject WHERE SubjectID =@id";
                using(var cmd = new SQLiteCommand(delquery, db))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteSubjectFromLecturerSubjects(int id)
        {
            using (var db = DB_Connection.GetConnection())
            {
                string delquery = "DELETE FROM LecturerSubjects WHERE SubjectID =@id";
                using (var cmd = new SQLiteCommand(delquery, db))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Subject> AllSubjects()
        {
            var subjects = new List<Subject>();
            using (var conn = DB_Connection.GetConnection())
            {
                string getquery = "SELECT * FROM Subjects";
                using (var cmd = new SQLiteCommand(getquery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Subject subject = new Subject
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }

        public Subject GetSubjectById(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Subjects WHERE ID = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Subject
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }
            return null;
        }
        public static List<Subject> GetIdAndNameOnly()
        {
            var list = new List<Subject>();

            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID, Name FROM Subjects";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Subject
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return list;
        }

    }
}
