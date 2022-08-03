using FoxNet.Hotel.Service;
using FoxNet.Hotel.BO;
using System;
using FoxNet.Hotel.Common;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class RoomServiceTest
    {
        [TestMethod]
        public void AddRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });
                db.SaveChanges();

                var addedRoom = db.Rooms.ToList();

                Assert.AreEqual(111, addedRoom[0].Number);
            }
        }

        [TestMethod]
        public void EditRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                var roomId = roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });

                var room = roomService.GetRoom(roomId);
                room.Booked = true;

                roomService.EditRoom(room);

                Assert.AreEqual(true, room.Booked);
            }
        }

        [TestMethod]
        public void GetRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                var addedRoomId = roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });

                var readedRoom = roomService.GetRoom(addedRoomId);

                Assert.AreEqual(300.45F, readedRoom.Price);
            }
        }

        [TestMethod]
        public void GetRoomsTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });
                roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });

                var roomsList = roomService.GetRooms();

                Assert.AreEqual(2, roomsList.Count);
            }
        }

        [TestMethod]
        public void SetRoomStateTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                var addedRoomId = roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });

                var room = roomService.GetRoom(addedRoomId);
                room.Booked = true;
                roomService.SetRoomState(room);
                db.SaveChanges();

                Assert.AreEqual(true, room.Booked);
            }
        }

        [TestMethod]
        public void DeleteRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                var addedRoomId = roomService.AddRoom(new DTO.RoomData()
                {
                    Number = 111,
                    BedsAmount = 3,
                    Price = 300.45F,
                    Bathroom = true,
                    Booked = false
                });

                roomService.DeleteRoom(addedRoomId);

                var rooms = roomService.GetRooms();

                Assert.AreEqual(0, rooms.Count);
            }
        }
    }
}