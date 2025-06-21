using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Unicom_TIC_Management.Controllers;
using Unicom_TIC_Management.Models;
using Unicom_TIC_Management.Repos;

namespace Unicom_TIC_Management.Controllers
{
    internal class ExamTimetablecontroller
    {
        public static List<ExamTimetable> GetAll()
        {
            var list = new List<ExamTimetable>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"SELECT et.ID, et.ExamID, e.Name as ExamName, et.SubjectID, s.Name as SubjectName, et.Date, et.Time
                                 FROM ExamTimetable et
                                 JOIN Exams e ON et.ExamID = e.ID
                                 JOIN Subjects s ON et.SubjectID = s.ID";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ExamTimetable
                        {
                            Id = reader.GetInt32(0),
                            ExamId = reader.GetInt32(1),
                            ExamName = reader.GetString(2),
                            SubjectId = reader.GetInt32(3),
                            SubjectName = reader.GetString(4),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Time = TimeSpan.Parse(reader["Time"].ToString())
                        });
                    }
                }
            }
            return list;
        }

        public static bool IsValidExamSchedule(int examId, int subjectId, DateTime date, TimeSpan time)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                // 1. Exam + Subject check
                string check1 = "SELECT COUNT(*) FROM ExamTimetable WHERE ExamID = @examId AND SubjectID = @subjectId";
                using (var cmd = new SQLiteCommand(check1, conn))
                {
                    cmd.Parameters.AddWithValue("@examId", examId);
                    cmd.Parameters.AddWithValue("@subjectId", subjectId);
                    if ((long)cmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("This subject is already scheduled for this exam.");
                        return false;
                    }
                        
                }

                // 2. Date & Time clash
                string check2 = "SELECT COUNT(*) FROM ExamTimetable WHERE Date = @date AND Time = @time";
                using (var cmd = new SQLiteCommand(check2, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@time", time.ToString());
                    if ((long)cmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("An exam is already scheduled at this date and time.");
                        return false;
                    }
                }

                // 3. Past Date
                if (date.Date < DateTime.Today)
                {
                    MessageBox.Show("Cannot schedule an exam in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string check3 = "SELECT COUNT(*) FROM Timetables WHERE Date = @date";
                using (var cmd = new SQLiteCommand(check3, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    if ((long)cmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("A class is already scheduled on this date.", "Clash Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                return true;
            }
        }

        public static bool Add(ExamTimetable et)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                if (!IsValidExamSchedule(et.ExamId, et.SubjectId, et.Date, et.Time))
                {
                    return false; 
                }
                string query = "INSERT INTO ExamTimetable (ExamID, SubjectID, Date, Time) VALUES (@exam, @subj, @date, @time)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@exam", et.ExamId);
                    cmd.Parameters.AddWithValue("@subj", et.SubjectId);
                    cmd.Parameters.AddWithValue("@date", et.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@time", et.Time.ToString());
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Edit(ExamTimetable et, int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "UPDATE ExamTimetable SET ExamID = @exam, SubjectID = @subj, Date = @date, Time = @time WHERE ID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@exam", et.ExamId);
                    cmd.Parameters.AddWithValue("@subj", et.SubjectId);
                    cmd.Parameters.AddWithValue("@date", et.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@time", et.Time.ToString());
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "DELETE FROM ExamTimetable WHERE ID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}
