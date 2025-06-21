using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Unicom_TIC_Management.Models;
using Unicom_TIC_Management.Repos;

namespace Unicom_TIC_Management.Controllers
{
    internal class Timetablecontroller
    {
        public static bool Add(Timetable timetable,DateTime date)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {
                    if (CheckTimetable(timetable, date))
                    {
                        string insertQuery = "INSERT INTO Timetables (LecturerID, SubjectID, Date, Time,Room) VALUES (@lecturerid, @subjectid, @date, @time,@room)";
                        using (var cmd = new SQLiteCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@lecturerid", timetable.LecturerId);
                            cmd.Parameters.AddWithValue("@subjectid", timetable.SubjectId);
                            cmd.Parameters.AddWithValue("@date", timetable.Date);
                            cmd.Parameters.AddWithValue("@time", timetable.Time);
                            cmd.Parameters.AddWithValue("@room", timetable.Room);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Timetable Addded Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred while adding the exam.\n\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool CheckTimetable(Timetable timetable, DateTime today)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                // 1. Check if an exam is scheduled at the same date and time
                string checkExamQuery = "SELECT COUNT(*) FROM ExamTimetable WHERE Date = @date AND Time = @time";
                using (var cmd = new SQLiteCommand(checkExamQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@date", timetable.Date);
                    cmd.Parameters.AddWithValue("@time", timetable.Time);
                    long count = Convert.ToInt64(cmd.ExecuteScalar() ?? 0);

                    if (count > 0)
                    {
                        MessageBox.Show("An exam is already scheduled at this date and time.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                string checkClassQuery = "SELECT COUNT(*) FROM Timetables WHERE Date = @date AND Time = @time AND Room = @room";
                using (var cmd = new SQLiteCommand(checkClassQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@date", timetable.Date);
                    cmd.Parameters.AddWithValue("@time", timetable.Time);
                    cmd.Parameters.AddWithValue("@room", timetable.Room);
                    long count = Convert.ToInt64(cmd.ExecuteScalar() ?? 0);

                    if (count > 0)
                    {
                        MessageBox.Show("A class is already scheduled at this date, time, and room.", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                string checkSubLecturerQuery = "SELECT COUNT(*) FROM LecturerSubjects WHERE SubjectID = @subid AND LecturerID = @lecid";
                using (var cmd = new SQLiteCommand(checkSubLecturerQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@subid", timetable.SubjectId);
                    cmd.Parameters.AddWithValue("@lecid", timetable.LecturerId);
                    long count = Convert.ToInt64(cmd.ExecuteScalar() ?? 0);

                    if (count == 0)
                    {
                        MessageBox.Show("The selected lecturer is not assigned to this subject.", "Invalid Assignment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (timetable.Date < today)
                {
                    MessageBox.Show("The date cannot be in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
        }


        public static List<Timetable> GetAll()
        {
            var list = new List<Timetable>();

            using (var conn = DB_Connection.GetConnection())
            {
                string query = @"
            SELECT 
                t.ID,
                t.SubjectID,
                s.Name AS SubjectName,
                t.LecturerID,
                l.Name AS LecturerName,
                t.Date,
                t.Time,
                t.Room
            FROM Timetables t
            JOIN Subjects s ON t.SubjectID = s.ID
            JOIN Lecturers l ON t.LecturerID = l.ID";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Timetable
                        {
                            Id = reader.GetInt32(0),
                            SubjectId = reader.GetInt32(1),
                            SubjectName = reader.GetString(2),
                            LecturerId = reader.GetInt32(3),
                            LecturerName = reader.GetString(4),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Time = TimeSpan.Parse(reader["Time"].ToString()),
                            Room = reader["Room"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static bool Edit(Timetable timetable, int id, DateTime today)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {
                    if (Checkedit(timetable, id, today))
                    {
                        string updateQuery = @"UPDATE Timetables SET 
                                        LecturerID = @lecid, 
                                        SubjectID = @subid, 
                                        Date = @date, 
                                        Time = @time, 
                                        Room = @room 
                                        WHERE ID = @id";

                        using (var cmd = new SQLiteCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@lecid", timetable.LecturerId);
                            cmd.Parameters.AddWithValue("@subid", timetable.SubjectId);
                            cmd.Parameters.AddWithValue("@date", timetable.Date);
                            cmd.Parameters.AddWithValue("@time", timetable.Time);
                            cmd.Parameters.AddWithValue("@room", timetable.Room);
                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Class updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    return false; // If validation fails
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static bool Checkedit(Timetable timetable, int id, DateTime today)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                // Check room conflict
                string checkRoomQuery = @"SELECT COUNT(*) FROM Timetables 
                                  WHERE Date = @date AND Time = @time AND Room = @room AND ID != @id";
                using (var cmd = new SQLiteCommand(checkRoomQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@date", timetable.Date);
                    cmd.Parameters.AddWithValue("@time", timetable.Time);
                    cmd.Parameters.AddWithValue("@room", timetable.Room);
                    cmd.Parameters.AddWithValue("@id", id);

                    long count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("A class already exists at this time in the same room.",
                                        "Room Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Check exam conflict
                string checkExamQuery = @"SELECT COUNT(*) FROM Exams 
                                  WHERE Date = @date AND Time = @time";
                using (var cmd = new SQLiteCommand(checkExamQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@date", timetable.Date);
                    cmd.Parameters.AddWithValue("@time", timetable.Time);

                    long count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("An exam is scheduled at this date and time.",
                                        "Exam Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Check if the lecturer is assigned to the subject
                string checkLecSubQuery = @"SELECT COUNT(*) FROM LecturerSubjects 
                                    WHERE SubjectID = @subid AND LecturerID = @lecid";
                using (var cmd = new SQLiteCommand(checkLecSubQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@subid", timetable.SubjectId);
                    cmd.Parameters.AddWithValue("@lecid", timetable.LecturerId);

                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("The selected lecturer is not assigned to this subject.",
                                        "Invalid Assignment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Check if date is not in the past
                if (timetable.Date < today.Date)
                {
                    MessageBox.Show("Class date cannot be in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
        }


        public static void Delete(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                try
                {
                    string delQuery = "DELETE FROM Timetables WHERE ID = @id";
                    using (var cmd = new SQLiteCommand(delQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Timetable entry deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Timetable entry not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the timetable entry.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

