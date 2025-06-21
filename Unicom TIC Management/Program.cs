using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Repos;
using Unicom_TIC_Management.View;

namespace Unicom_TIC_Management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.CreateTables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (IsUsersTableEmpty())
            {
                Application.Run(new SignupForm());
            }
            else
            {
                Application.Run(new LoginForm());
            }

        }
        public static bool IsUsersTableEmpty()
        {
            using (var connection = DB_Connection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users";
                using (var command = new SQLiteCommand(query, connection))
                {
                    long count = (long)command.ExecuteScalar(); 
                    return count == 0;
                }
            }
        }
    }
}
