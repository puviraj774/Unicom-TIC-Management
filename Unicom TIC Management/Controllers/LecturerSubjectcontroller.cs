using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Repos;

namespace Unicom_TIC_Management.Controllers
{
    internal class LecturerSubjectcontroller
    {
        public bool AddLecturerSubject(int lecturerId, int subjectId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string checkQuery = @"SELECT COUNT(*) FROM LecturerSubjects 
                              WHERE LecturerID = @lecturerId AND SubjectID = @subjectId";
                using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@lecturerId", lecturerId);
                    checkCmd.Parameters.AddWithValue("@subjectId", subjectId);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        return false; // already exists
                    }
                }

                string insertQuery = @"INSERT INTO LecturerSubjects (LecturerID, SubjectID) 
                               VALUES (@lecturerId, @subjectId)";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@lecturerId", lecturerId);
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    cmd.ExecuteNonQuery();
                }

                return true; // success
            }
        }


        public bool DeleteLecturerSubject(int lecturerId, int subjectId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string deleteQuery = @"DELETE FROM LecturerSubjects 
                               WHERE LecturerID = @lecturerId AND SubjectID = @subjectId";

                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@lecturerId", lecturerId);
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        public static DataTable GetAllLecturerSubjects()
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"
                                SELECT 
                                l.Name AS [Lecturer Name],
                                s.Name AS [Subject Name]
                                FROM LecturerSubjects ls
                                JOIN Lecturers l ON ls.LecturerID = l.ID
                                JOIN Subjects s ON ls.SubjectID = s.ID
                                ORDER BY l.Name, s.Name;";

                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public bool LecturerSubjectExists(int lecturerId, int subjectId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"SELECT COUNT(*) FROM LecturerSubjects WHERE LecturerID = @lecturerId AND SubjectID = @subjectId";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lecturerId", lecturerId);
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    return (long)cmd.ExecuteScalar() > 0;
                }
            }
        }



    }
}
