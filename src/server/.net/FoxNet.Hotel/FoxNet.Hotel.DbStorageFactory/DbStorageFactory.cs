using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Data.Entity;
using System.Data.SQLite;

namespace FoxNet.Hotel.DbStorage
{
    public class DbStorageFactory
    {
        private static string GetDbDirectory()
        {
            string currentPath = Environment.CurrentDirectory;
            string dbPath = Path.Combine(currentPath, "HotelDb.sqlite");

            return dbPath;
        }

        public static void CreateDb()
        {
            string currentPath = Environment.CurrentDirectory;
            string rawPath = Path.GetFullPath(Path.Combine(currentPath, @"../../../../"));

            bool dbExist = CheckIfDbExist();

            if (dbExist == false)
            {
                var conn = new SQLiteConnection($"Data Source=HotelDb.sqlite;Version=3;");

                conn.Open();

                CreateStructures(conn, rawPath);
                InsertData(conn, rawPath);

                conn.Close();
            }
        }

        private static void CreateStructures(SQLiteConnection connection, string rawPath)
        {
            string dbModel = Path.Combine(rawPath, "Db\\Models\\DbModel.sql");

            string create = File.ReadAllText(dbModel);

            SQLiteCommand createCommand = new(create, connection);

            createCommand.ExecuteNonQuery();
        }

        private static void InsertData(SQLiteConnection connection, string rawPath)
        {
            string dbData = Path.Combine(rawPath, "Db\\Models\\HotelData.sql");

            string insert = File.ReadAllText(dbData);

            SQLiteCommand insertCommand = new(insert, connection);

            insertCommand.ExecuteNonQuery();
        }

        public static void MoveDb()
        {
            string currentPath = Environment.CurrentDirectory;
            string rawPath = Path.GetFullPath(Path.Combine(currentPath, @"../../../../"));

            string dbName = "HotelDb.sqlite";
            string dbPath = Path.Combine(currentPath, dbName);

            string webApiPath = $"FoxNet.Hotel.WebAPI\\{dbName}";

            string newPath = Path.Combine(rawPath, webApiPath);

            File.Move(dbPath, newPath, true);
        }

        private static bool CheckIfDbExist()
        {
            string db = GetDbDirectory();

            if (File.Exists(db))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}