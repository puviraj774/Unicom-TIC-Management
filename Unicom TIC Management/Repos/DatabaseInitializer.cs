using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Repos
{
    internal class DatabaseInitializer
    {
        public static void CreateTables()
        {
            using (var connection = DB_Connection.GetConnection())
            {
                using (var cmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                string TableQuery = @"CREATE TABLE IF NOT EXISTS Users (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Username TEXT NOT NULL UNIQUE,
                                                Password TEXT NOT NULL,
                                                Role TEXT NOT NULL
                                            );  

                                        CREATE TABLE IF NOT EXISTS Courses (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Name TEXT NOT NULL UNIQUE
                                            );

                                        CREATE TABLE IF NOT EXISTS Subjects (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Name TEXT NOT NULL UNIQUE
                                            );

                                        CREATE TABLE IF NOT EXISTS CourseSubject(
                                                SubjectID INTEGER NOT NULL,
                                                CourseID  INTEGER NOT NULL,
                                                PRIMARY KEY (CourseID,SubjectID),
                                                FOREIGN KEY (SubjectID) REFERENCES Subjects(ID),
                                                FOREIGN KEY (CourseID) REFERENCES Courses(ID)
                                            );

                                        CREATE TABLE IF NOT EXISTS Students (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Name TEXT NOT NULL,
                                                NIC VARCHAR(12) NOT NULL UNIQUE,
                                                CourseID INTEGER,
                                                UserID INTEGER,
                                                FOREIGN KEY (UserID)   REFERENCES Users(ID),
                                                FOREIGN KEY (CourseID) REFERENCES Courses(ID)
                                            );

                                        CREATE TABLE IF NOT EXISTS Staff (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Name TEXT NOT NULL,
                                                NIC VARCHAR(25) NOT NULL UNIQUE,
                                                UserID INTEGER,
                                                FOREIGN KEY (UserID)   REFERENCES Users(ID)
                                            );

                                        CREATE TABLE IF NOT EXISTS Lecturers(
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Name TEXT NOT NULL,
                                                NIC VARCHAR(12) NOT NULL UNIQUE,
                                                UserID INTEGER,
                                                FOREIGN KEY (UserID)   REFERENCES Users(ID)
                                            );

                                        CREATE TABLE IF NOT EXISTS LecturerSubjects (
                                                LecturerID INTEGER,
                                                SubjectID INTEGER,
                                                PRIMARY KEY (LecturerID, SubjectID),
                                                FOREIGN KEY (LecturerID) REFERENCES Lecturers(ID),
                                                FOREIGN KEY (SubjectID) REFERENCES Subjects(ID)
                                            );

                                        CREATE TABLE IF NOT EXISTS Exams (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Name TEXT UNIQUE NOT NULL
                                            );

                                        CREATE TABLE IF NOT EXISTS ExamTimetable(
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                ExamID INTEGER NOT NULL,
                                                SubjectID INTEGER NOT NULL,
                                                Date TEXT NOT NULL,
                                                Time TEXT NOT NULL,
                                                UNIQUE (ExamID,SubjectID),
                                                FOREIGN KEY (SubjectID) REFERENCES Subjects(ID),
                                                FOREIGN KEY (ExamID) REFERENCES Exams(ID)
                                            );

                                        CREATE TABLE IF NOT EXISTS Marks(
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                StudentID INTEGER,
                                                ExamTimetableID INTEGER,
                                                Score INTEGER CHECK(Score BETWEEN 0 AND 100),
                                                FOREIGN KEY (StudentID) REFERENCES Students(ID),
                                                FOREIGN KEY (ExamTimetableID) REFERENCES ExamTimetable(ID),
                                                UNIQUE (StudentID, ExamTimetableID)
                                            );

                                        CREATE TABLE IF NOT EXISTS Timetables(
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                SubjectID INTEGER,
                                                LecturerID INTEGER,
                                                Date TEXT NOT NULL,
                                                Time TEXT NOT NULL,
                                                Room TEXT NOT NULL,
                                                UNIQUE(Date, Time, Room),
                                                FOREIGN KEY (SubjectID) REFERENCES Subjects(ID),
                                                FOREIGN KEY (LecturerID) REFERENCES Lecturers(ID)                                    
                                            );

                                        CREATE TABLE IF NOT EXISTS StudentAttendance(
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                StudentID INTEGER NOT NULL,
                                                Date TEXT NOT NULL,
                                                Status TEXT NOT NULL CHECK(Status IN ('Present', 'Absent')),
                                                UNIQUE(StudentID, Date),
                                                FOREIGN KEY (StudentID) REFERENCES Students(ID)
                                            );

                                        ";

                SQLiteCommand command = new SQLiteCommand(TableQuery,connection);   
                command.ExecuteNonQuery();
            }
        }
    }
}
