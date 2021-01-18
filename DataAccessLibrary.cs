using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

using Microsoft.Data.Sqlite;

namespace zoom_attendance
{
    public static class DataAccessLibrary
    {
        public async static void InitialiseDatabase()
        {
            // Open or create a sqlite database
            await ApplicationData.Current.LocalFolder.CreateFileAsync("attendance.db", CreationCollisionOption.OpenIfExists);
            
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "attendance.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = 
                    @"
                        CREATE TABLE IF NOT
                        EXISTS AttendanceTable (Primary_Key INTEGER PRIMARY KEY,
                        Name TEXT NULL, Email TEXT NOT NULL UNIQUE, DiscordID TEXT NULL)
                    ";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

        public static void AddMember(Attendance member)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "attendance.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand
                {
                    Connection = db
                };

                // We need to check if the email id exists

                // if it exists, we just update the dates

                // else make a new entry
            }
        }

        public static List<Attendance> GetData()
        {
            List<Attendance> attendees = new List<Attendance>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "attendance.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("");
            }

            return attendees;
        }
    }
}
