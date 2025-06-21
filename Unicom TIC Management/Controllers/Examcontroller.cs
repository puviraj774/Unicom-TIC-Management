using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Repos;
using Unicom_TIC_Management.Models;

namespace Unicom_TIC_Management.Controllers
{
    internal class Examcontroller
    {
        public static List<Exam> GetAll()
        {
            var list = new List<Exam>();
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "SELECT ID, Name FROM Exams";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Exam
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }

        public static bool Add(string name)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Exams WHERE Name = @name";
                using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@name", name.Trim());
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("This exam name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                string query = "INSERT INTO Exams (Name) VALUES (@name)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name.Trim());

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static bool Delete(int id)
        {
            using (var conn = DB_Connection.GetConnection())
            {
                string query = "DELETE FROM Exams WHERE ID = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
