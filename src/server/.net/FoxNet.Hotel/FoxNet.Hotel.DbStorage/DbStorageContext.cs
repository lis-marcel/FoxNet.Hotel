using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.BO;
using Microsoft.EntityFrameworkCore;

namespace FoxNet.Hotel.DbStorage
{
    public class DbStorageContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public string DbPath { get; }

        public DbStorageContext(string dbPath) : base() => DbPath = dbPath;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data source = {DbPath}");
    }
}
