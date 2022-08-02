using FoxNet.Hotel.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoxNet.Hotel.DbStorage
{
    public class DbStorage : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public string DbPath { get; }

        public static DbStorageContext GetInstance()
        {
            var path = @"C:\temp\Dbs";
            var ctx = new DbStorageContext(Path.Combine(path, "hotel.sqlite"));

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (ctx.Database.CanConnect())
            {
                ctx.Database.EnsureCreated();

                //LoadData(ctx);
            }

            return ctx;
        }

        public DbStorage(string dbPath) : base() => DbPath = dbPath;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data source = {DbPath}");

        private static void LoadData(DbStorageContext ctx)
        {
            ctx.Add(new Room() { Id = 1, Number = 1, BedsAmount = 5, Price = 149.99F, Bathroom = true, Booked = false });
            ctx.Add(new User() { Id = 1, Name = "Jan", Surname = "Kowalski", Birth = new DateTime(1970, 2, 15), AccountType = Type.Admin, Phone = 123456789, Password = "okok123", Money = 345.01F });
            ctx.Add(new Reservation() { Id = 1, FirstDay = new DateTime(2022, 8, 1), LastDay = new DateTime(2022, 8, 15), RoomId = 1, UserId = 1 });

            ctx.SaveChanges();
        }
    }
}
