﻿using FoxNet.Hotel.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace FoxNet.Hotel.Common
{
    public class DbStorage : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public string DbPath { get; set; }
        public bool AutoRemoveDb { get; set; }

        public DbStorage()
        {
            DbPath = Path.Combine(Environment.CurrentDirectory, "hotel.sqlite");
        }

        public override void Dispose()
        {
            if (AutoRemoveDb)
            {
                Database.EnsureDeleted();
            }

            base.Dispose();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data source = {DbPath}");

        public static DbStorage GetDefault()
        {
            var db = new DbStorage();

            string basePath = string.Join(@"\", db.DbPath.Split('\\').Take(7));
            db.DbPath = Path.Combine(basePath, "FoxNet.Hotel.WebAPI\\hotel.sqlite");

            if (!db.Database.CanConnect())
            {
                var modelPath = Path.Combine(basePath, "Db\\Models\\DbModel.sql");
                var dbModel = File.ReadAllText(modelPath);

                var dataPath = Path.Combine(basePath, "Db\\Models\\HotelData.sql");
                var dataModel = File.ReadAllText(dataPath);

                db.Database.ExecuteSqlRaw(dbModel);
                db.Database.ExecuteSqlRaw(dataModel);

                Console.WriteLine("Created database.");
            }

            else
            {
                Console.WriteLine("Database already exists!");
            }

            db.SaveChanges();

            return db;
        }

        public static DbStorage GetTestInstance()
        {
            var db = new DbStorage
            {
                DbPath = Path.Combine(Environment.CurrentDirectory, "test.sqlite"),
                AutoRemoveDb = true
            };
            db.Database.EnsureCreated();

            return db;
        }
    }
}
