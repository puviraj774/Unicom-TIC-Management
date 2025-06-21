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
    internal class Markcontroller
    {
        public static List<Mark> GetAll()
        {
            var list = new List<Mark>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"
                    SELECT 
                        m.ID,
                        m.StudentID,
                        s.Name AS StudentName,
                        m.ExamTimetableID,
                        e.Name AS ExamName,
                        et.SubjectID,
                        sub.Name AS SubjectName,
                        m.Score
                    FROM Marks m
                    JOIN Students s ON m.StudentID = s.ID
                    JOIN ExamTimetable et ON m.ExamTimetableID = et.ID
                    JOIN Exams e ON et.ExamID = e.ID
                    JOIN Subjects sub ON et.SubjectID = sub.ID";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Mark
                        {
                            Id = reader.GetInt32(0),
                            StudentId = reader.GetInt32(1),
                            StudentName = reader.GetString(2),
                            ExamTimetableId = reader.GetInt32(3),
                            ExamName = reader.GetString(4),
                            SubjectId = reader.GetInt32(5),
                            SubjectName = reader.GetString(6),
                            Score = reader.GetInt32(7)
                        });
                    }
                }
            }
            return list;
        }

        public static bool AddMark(Mark mark)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string examQuery = "SELECT Date FROM ExamTimetable WHERE ID = @id";

                using (var examCmd = new SQLiteCommand(examQuery, conn))
                {
                    examCmd.Parameters.AddWithValue("@id", mark.ExamTimetableId);
                    var examDateObj = examCmd.ExecuteScalar();
                    if (examDateObj == null)
                    {
                        MessageBox.Show("Invalid exam timetable.", "Error");
                        return false;
                    }

                    DateTime examDate = Convert.ToDateTime(examDateObj);

                    string attendanceQuery = @"SELECT Status FROM StudentAttendance WHERE StudentID = @sid AND Date = @date";
                    using (var attendanceCmd = new SQLiteCommand(attendanceQuery, conn))
                    {
                        attendanceCmd.Parameters.AddWithValue("@sid", mark.StudentId);
                        attendanceCmd.Parameters.AddWithValue("@date", examDate.ToString("yyyy-MM-dd"));
                        var statusObj = attendanceCmd.ExecuteScalar();

                        if (statusObj == null || statusObj.ToString() != "Present")
                        {
                            MessageBox.Show("Student not present on exam date.", "Validation");
                            return false;
                        }
                    }

                    string insert = @"INSERT INTO Marks (StudentID, ExamTimetableID, Score) VALUES (@sid, @etid, @score)";
                    using (var cmd = new SQLiteCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", mark.StudentId);
                        cmd.Parameters.AddWithValue("@etid", mark.ExamTimetableId);
                        cmd.Parameters.AddWithValue("@score", mark.Score);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
        }

        public static bool EditMark(Mark mark)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string getDateQuery = "SELECT Date FROM ExamTimetable WHERE ID = @id";
                string examDate = null;

                using (var cmd = new SQLiteCommand(getDateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", mark.ExamTimetableId);
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Invalid timetable.");
                        return false;
                    }
                    examDate = result.ToString();
                }

                string checkAttendance = @"SELECT COUNT(*) FROM StudentAttendance WHERE StudentID = @sid AND Date = @date AND Status = 'Present'";
                using (var cmd = new SQLiteCommand(checkAttendance, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", mark.StudentId);
                    cmd.Parameters.AddWithValue("@date", examDate);
                    if ((long)cmd.ExecuteScalar() == 0)
                    {
                        MessageBox.Show("No valid attendance.");
                        return false;
                    }
                }

                string update = @"UPDATE Marks SET Score = @score WHERE StudentID = @sid AND ExamTimetableID = @etid";
                using (var cmd = new SQLiteCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@score", mark.Score);
                    cmd.Parameters.AddWithValue("@sid", mark.StudentId);
                    cmd.Parameters.AddWithValue("@etid", mark.ExamTimetableId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }
        public static List<Mark> GetMarksByStudentId(int studentId)
        {
            var list = new List<Mark>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"
            SELECT 
                m.ID,
                m.StudentID,
                s.Name AS StudentName,
                m.ExamTimetableID,
                e.Name AS ExamName,
                et.SubjectID,
                sub.Name AS SubjectName,
                m.Score
            FROM Marks m
            JOIN Students s ON m.StudentID = s.ID
            JOIN ExamTimetable et ON m.ExamTimetableID = et.ID
            JOIN Exams e ON et.ExamID = e.ID
            JOIN Subjects sub ON et.SubjectID = sub.ID
            WHERE m.StudentID = @studentId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Mark
                            {
                                Id = reader.GetInt32(0),
                                StudentId = reader.GetInt32(1),
                                StudentName = reader.GetString(2),
                                ExamTimetableId = reader.GetInt32(3),
                                ExamName = reader.GetString(4),
                                SubjectId = reader.GetInt32(5),
                                SubjectName = reader.GetString(6),
                                Score = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            return list;
        }
        public static int? GetStudentIdByUserId(int userId)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID FROM Students WHERE UserID = @userId";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    var result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int sid))
                        return sid;
                }
            }
            return null; 
        }

    }
}

