using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Repos
{
    internal class DB_Connection
    {
        private static string ConnectionString = "Data Source=UnicomTICDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection  = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
