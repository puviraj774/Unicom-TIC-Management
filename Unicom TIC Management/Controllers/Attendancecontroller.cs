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
    internal class Attendancecontroller
    {
        public static bool Add(Attendence attendance)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM StudentAttendance WHERE StudentID = @id AND Date = @date";
                using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", attendance.StudentId);
                    checkCmd.Parameters.AddWithValue("@date", attendance.Date.Date.ToString("yyyy-MM-dd"));

                    long count = (long)(checkCmd.ExecuteScalar() ?? 0);
                    if (count > 0)
                    {
                        MessageBox.Show("Attendance already marked for this student on this date.");
                        return false;
                    }
                }


                string insert = "INSERT INTO StudentAttendance (StudentID, Date, Status) VALUES (@sid, @date, @status)";
                using (var cmd = new SQLiteCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", attendance.StudentId);
                    cmd.Parameters.AddWithValue("@date", attendance.Date.Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", attendance.Status);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }
        public static List<Attendence> GetAll()
        {
            var list = new List<Attendence>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"SELECT a.ID, a.StudentID, s.Name, a.Date, a.Status
                         FROM StudentAttendance a
                         JOIN Students s ON a.StudentID = s.ID";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Attendence
                        {
                            Id = reader.GetInt32(0),
                            StudentId = reader.GetInt32(1),
                            Studentname = reader.GetString(2),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Status = reader.GetString(4)
                        });
                    }
                }
            }
            return list;
        }
        public static bool UpdateAttendance(int id, string status)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "UPDATE StudentAttendance SET Status = @status WHERE ID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        public static List<DateTime> GetValidDatesForAttendance()
        {
            var dates = new List<DateTime>();

            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"
            SELECT DISTINCT Date FROM ExamTimetable
            UNION
            SELECT DISTINCT Date FROM Timetables";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dates.Add(Convert.ToDateTime(reader["Date"]));
                    }
                }
            }

            return dates;
        }



    }
}
