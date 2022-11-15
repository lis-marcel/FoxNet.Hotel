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

            if (!db.Database.CanConnect())
            {
                db.Database.EnsureCreated();
            }

            else
            {
                Console.WriteLine("Database already exists!");
            }

            return db;
        }

        public static DbStorage GetTestInstance()
        {
            var db = new DbStorage();
            db.DbPath = Path.Combine(Environment.CurrentDirectory, "test.sqlite");
            db.AutoRemoveDb = true;
            db.Database.EnsureCreated();

            return db;
        }

        public static void InsertTestData(DbStorage db)
        {
            db.Add(new User() { Name = "Felek",
                Surname = "Kici",
                Email = "felek.kici@mail.com",
                Birth = new DateOnly(2004, 1, 1),
                Password = "kiebaska123",
                Phone = "123456789",
                Money = "199.56",
                AccountType = Type.Client 
            });
            db.Add(new User()
            {
                Name = "Kokosek",
                Surname = "Nici",
                Email = "kokosek.nici@mail.com",
                Birth = new DateOnly(2003, 3, 15),
                Password = "schabik123",
                Phone = "987654321",
                Money = "391.23",
                AccountType = Type.Client
            });

            db.Add(new Room() { 
                Number = "111",
                BedsAmount = "3",
                Bathroom = true,
                Price = "45.33",
            });
            db.Add(new Room()
            {
                Number = "222",
                BedsAmount = "2",
                Bathroom = true,
                Price = "29.45",
            });
            db.Add(new Room()
            {
                Number = "333",
                BedsAmount = "1",
                Bathroom = true,
                Price = "60.56",
            });
            db.Add(new Room()
            {
                Number = "444",
                BedsAmount = "5",
                Bathroom = true,
                Price = "80.89",
            });

            db.Add(new Reservation() { 
                FirstDay = new DateOnly(2022,8,13),
                LastDay = new DateOnly(2022, 8, 15),
                RoomId = 1,
                UserId = 1
            });
            db.Add(new Reservation()
            {
                FirstDay = new DateOnly(2022, 8, 13),
                LastDay = new DateOnly(2022, 8, 16),
                RoomId = 4,
                UserId = 2
            });
            db.Add(new Reservation()
            {
                FirstDay = new DateOnly(2022, 8, 15),
                LastDay = new DateOnly(2022, 8, 20),
                RoomId = 1,
                UserId = 2
            });

            db.SaveChanges();
        }
    }
}
