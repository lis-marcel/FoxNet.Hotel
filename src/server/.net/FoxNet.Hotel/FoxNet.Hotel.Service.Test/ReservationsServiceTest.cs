using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class ReservationsServiceTest
    {
        [TestMethod]
        public void MakeReservationTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

            var userService = new UserService(db);
            var userId = userService.AddUser(new DTO.UserData()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Birth = new DateTime(1920, 1, 14),
                AccountType = DTO.Type.Worker,
                Money = 700.89F,
                Password = "123",
                Phone = 123456689
            });

            var roomService = new RoomService(db);
            var roomId = roomService.AddRoom(new DTO.RoomData()
            {
                Number = 111,
                BedsAmount = 3,
                Price = 300.45F,
                Bathroom = true,
                Booked = false
            });

            var reservationService = new ReservationService(db);
            reservationService.MakeReservation(new DTO.ReservationData()
            {
                FirstDay = new DateTime(2022, 1, 19),
                LastDay = new DateTime(2022, 1, 25),
                RoomId = roomId,
                UserId = userId
            });

            var reservationsList = db.Reservations.ToList();

            Assert.AreEqual(1, reservationsList.Count);

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void DeleteReservation()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

            var userService = new UserService(db);
            var userId = userService.AddUser(new DTO.UserData()
            {
                Name = "Jan",
                Surname = "Kowalski",
                Birth = new DateTime(1920, 1, 14),
                AccountType = DTO.Type.Worker,
                Money = 700.89F,
                Password = "123",
                Phone = 123456689
            });

            var roomService = new RoomService(db);
            var roomId = roomService.AddRoom(new DTO.RoomData()
            {
                Number = 111,
                BedsAmount = 3,
                Price = 300.45F,
                Bathroom = true,
                Booked = false
            });

            var reservationService = new ReservationService(db);
            var reservationId = reservationService.MakeReservation(new DTO.ReservationData()
            {
                FirstDay = new DateTime(2022, 1, 19),
                LastDay = new DateTime(2022, 1, 25),
                RoomId = roomId,
                UserId = userId
            });

            reservationService.DeleteReservation(reservationId);

            var reservationsList = db.Reservations.ToList();

            Assert.AreEqual(0, reservationsList.Count);

            db.Database.EnsureDeleted();
            db.Dispose();
        }
    }
}