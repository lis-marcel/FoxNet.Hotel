using FoxNet.Hotel.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoxNet.Hotel.Common
{
    public class DbStorage : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public string DbPath { get; }

        public DbStorage()
        {
            var path = @"C:\Users\lisma\.FoxNet\Hotel\src\server\.net\FoxNet.Hotel\DB";
            DbPath = Path.Combine(path, "hotel.sqlite");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data source = {DbPath}");

        public static DbStorage GetDefault()
        {
            var db = new DbStorage();
            db.Database.EnsureCreated();

            return db;
        }
    }
}
