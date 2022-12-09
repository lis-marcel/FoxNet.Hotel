using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class ReservationsServiceTest
    {
        #region Test objects
        UserData testUserObject = new UserData()
        {
            UserName = "Jan",
            UserSurname = "Kowalski",
            Birth = new DateOnly(1920, 1, 14),
            AccountType = DTO.Type.Worker,
            Money = "700.89D",
            Password = "123",
            Phone = "123456689"
        };

        RoomData testRoomObject = new RoomData()
        {
            RoomNumber = "111",
            BedsAmount = "3",
            Price = "300.45D",
            Bathroom = true,
        };
        #endregion

        #region Test methods
        [TestMethod]
        public void MakeReservationTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);
                var roomService = new RoomService(db);
                var reservationService = new ReservationService(db);

                var userId = userService.AddUser(testUserObject);
                var roomId = roomService.AddRoom(testRoomObject);

                reservationService.MakeReservation(new DTO.ReservationData()
                {
                    FirstDay = new DateOnly(2022, 1, 19),
                    LastDay = new DateOnly(2022, 1, 25),
                    RoomId = roomId,
                    UserId = userId
                });

                var reservationsList = db.Reservations.ToList();

                Assert.AreEqual(1, reservationsList.Count);
            }
        }

        [TestMethod]
        public void DeleteReservation()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var userService = new UserService(db);
                var roomService = new RoomService(db);
                var reservationService = new ReservationService(db);

                var userId = userService.AddUser(testUserObject);
                var roomId = roomService.AddRoom(testRoomObject);

                var reservationId = reservationService.MakeReservation(new DTO.ReservationData()
                {
                    FirstDay = new DateOnly(2022, 1, 19),
                    LastDay = new DateOnly(2022, 1, 25),
                    RoomId = roomId,
                    UserId = userId
                });

                reservationService.DeleteReservation(reservationId);

                var reservationsList = db.Reservations.ToList();

                Assert.AreEqual(0, reservationsList.Count);
            }
        }
        #endregion
    }
}