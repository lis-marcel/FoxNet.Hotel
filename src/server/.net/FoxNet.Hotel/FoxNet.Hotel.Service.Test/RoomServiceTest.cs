using FoxNet.Hotel.Service;
using FoxNet.Hotel.BO;
using System;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class RoomServiceTest
    {
        #region Test objects
        RoomData testRoom1 = new()
        {
            RoomId = 1,
            RoomNumber = "111",
            BedsAmount = "1",
            Price = "100.10D",
            Bathroom = true,
        };
        RoomData testRoom2 = new()
        {
            RoomId = 2,
            RoomNumber = "222",
            BedsAmount = "2",
            Price = "200.99D",
            Bathroom = true,
        };
        RoomData testRoom3 = new()
        {
            RoomId = 3,
            RoomNumber = "333",
            BedsAmount = "3",
            Price = "300.45D",
            Bathroom = true,
        };
        RoomData testRoom4 = new()
        {
            RoomId = 4,
            RoomNumber = "444",
            BedsAmount = "3",
            Price = "440.99D",
            Bathroom = true,
        };
        RoomData testRoom5 = new()
        {
            RoomId = 5,
            RoomNumber = "555",
            BedsAmount = "4",
            Price = "101.99D",
            Bathroom = true,
        };
        RoomData testRoom6 = new()
        {
            RoomId = 6,
            RoomNumber = "666",
            BedsAmount = "4",
            Price = "101.99D",
            Bathroom = true,
        };

        UserData testUser1 = new()
        {
            UserId = 1,
            UserName = "Pat",
            UserSurname = "Czech",
            Birth = new DateOnly(1999, 11, 19),
            AccountType = DTO.Type.Client,
            Money = "11.89D",
            Password = "412",
            Phone = "765456689"
        };
        UserData testUser2 = new()
        {
            UserId = 2,
            UserName = "Fat",
            UserSurname = "Mat",
            Birth = new DateOnly(2003, 3, 10),
            AccountType = DTO.Type.Client,
            Money = "11.11D",
            Password = "123",
            Phone = "765723689"
        };

        ReservationData testReservation1 = new()
        {
            FirstDay = new DateOnly(2022, 5, 10),
            LastDay = new DateOnly(2022, 5, 18),
            RoomId = 1,
            UserId = 1,
        };
        ReservationData testReservation2 = new()
        {
            FirstDay = new DateOnly(2022, 8, 10),
            LastDay = new DateOnly(2022, 8, 18),
            RoomId = 3,
            UserId = 2,
        };
        ReservationData testReservation3 = new()
        {
            FirstDay = new DateOnly(2022, 8, 13),
            LastDay = new DateOnly(2022, 8, 15),
            RoomId = 1,
            UserId = 2,
        };
        ReservationData testReservation4 = new()
        {
            FirstDay = new DateOnly(2022, 8, 14),
            LastDay = new DateOnly(2022, 8, 19),
            RoomId = 2,
            UserId = 2,
        };
        ReservationData testReservation5 = new()
        {
            FirstDay = new DateOnly(2022, 8, 15),
            LastDay = new DateOnly(2022, 8, 18),
            RoomId = 4,
            UserId = 1,
        };
        ReservationData testReservation6 = new()
        {
            FirstDay = new DateOnly(2022, 8, 20),
            LastDay = new DateOnly(2022, 8, 21),
            RoomId = 4,
            UserId = 2,
        };

        #endregion
        #region Insert test data
        public void InsertTestReservationData(ReservationService reservationService)
        {
            reservationService.MakeReservation(testReservation1);
            reservationService.MakeReservation(testReservation2);
            reservationService.MakeReservation(testReservation3);
            reservationService.MakeReservation(testReservation4);
            reservationService.MakeReservation(testReservation5);
            reservationService.MakeReservation(testReservation6);
        }
        public void InsertTestRoomData(RoomService roomService)
        {
            roomService.AddRoom(testRoom1);
            roomService.AddRoom(testRoom2);
            roomService.AddRoom(testRoom3);
            roomService.AddRoom(testRoom4);
            roomService.AddRoom(testRoom5);
            roomService.AddRoom(testRoom6);
        }
        public void InsertTestUserData(UserService userService)
        {
            userService.AddUser(testUser1);
            userService.AddUser(testUser2);
        }
        #endregion

        #region Test methods
        [TestMethod]
        public void FilterByDateTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var reservationService = new ReservationService(db);

                var firstDay = new DateOnly(2022, 8, 13).ToString();
                var lastDay = new DateOnly(2022, 8, 15).ToString();

                var roomsFilters = new DTO.FiltersData() { FirstDay = firstDay, LastDay = lastDay };

                InsertTestRoomData(roomService);
                InsertTestReservationData(reservationService);

                var freeRooms = roomService.GetFilteredRooms(roomsFilters);
                var freeRoomsCount = freeRooms.Count;

                Assert.AreEqual(2, freeRoomsCount);
            }
        }
        [TestMethod]
        public void FilterByRoomsTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                string beds = "3";

                var roomsFilters = new DTO.FiltersData() { Beds = beds };

                InsertTestRoomData(roomService);

                var freeRooms = roomService.GetFilteredRooms(roomsFilters);
                var freeRoomsCount = freeRooms.Count;

                Assert.AreEqual(2, freeRoomsCount);
            }
        }
        [TestMethod]
        public void FilterByBetweenPriceTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var max = "100.50";
                var min = "240.01";

                var roomsFilters = new DTO.FiltersData() { MaxPrice = max, MinPrice = min };

                InsertTestRoomData(roomService);

                var freeRooms = roomService.GetFilteredRooms(roomsFilters);
                var freeRoomsCount = freeRooms.Count;

             //   Assert.AreEqual(3, freeRoomsCount);
            }
        }
        [TestMethod]
        public void FilterLessThanMaxPriceTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var max = "240.50";

                var roomsFilters = new DTO.FiltersData() { MaxPrice = max };

                InsertTestRoomData(roomService);

                var freeRooms = roomService.GetFilteredRooms(roomsFilters);
                var freeRoomsCount = freeRooms.Count;

                Assert.AreEqual(3, freeRoomsCount);
            }
        }
        [TestMethod]
        public void FilterByDateRoomsTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var reservationService = new ReservationService(db);

                var firstDay = new DateOnly(2022, 8, 13).ToString();
                var lastDay = new DateOnly(2022, 8, 15).ToString();
                string beds = "4";

                var roomsFilters = new DTO.FiltersData() { FirstDay = firstDay, LastDay = lastDay, Beds = beds };

                InsertTestRoomData(roomService);
                InsertTestReservationData(reservationService);

                var freeRooms = roomService.GetFilteredRooms(roomsFilters);
                var freeRoomsCount = freeRooms.Count;

                Assert.AreEqual(1, freeRoomsCount);
            }
        }

        [TestMethod]
        public void AddRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                InsertTestRoomData(roomService);

                var addedRoom = db.Rooms.ToList();

                var parsedAddedRoomNumber = int.Parse(addedRoom[0].RoomNumber);
                Assert.AreEqual(111, parsedAddedRoomNumber);
            }
        }

        [TestMethod]
        public void GetRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var addedRoomId = roomService.AddRoom(testRoom3);

                var pickedRoom = roomService.GetRoom(addedRoomId);

                var parsedRoomPrice = double.Parse(pickedRoom.Price);
                Assert.AreEqual(300.45D, parsedRoomPrice);
            }
        }

        [TestMethod]
        public void EditRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var roomId = roomService.AddRoom(testRoom2);
                var room = roomService.GetRoom(roomId);
                var newNumber = 222.ToString();

                room.RoomNumber = newNumber;

                roomService.EditRoom(room);

                Assert.AreEqual(newNumber, room.RoomNumber);
            }
        }

        [TestMethod]
        public void GetRoomsTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                InsertTestRoomData(roomService);

                var roomsList = roomService.GetRooms();

                Assert.AreEqual(3, roomsList.Count);
            }
        }

        [TestMethod]
        public void DeleteRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                InsertTestRoomData(roomService);

                roomService.DeleteRoom(1);

                var rooms = roomService.GetRooms();

                Assert.AreEqual(2, rooms.Count);
            }
        }
        #endregion
    }
}