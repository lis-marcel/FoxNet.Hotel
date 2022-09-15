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
        RoomData testRoomData = new RoomData()
        {
            Number = "111",
            BedsAmount = "3",
            Price = "300.45D",
            Bathroom = true,
            Booked = false
        };
        #endregion

        #region Test methods
        [TestMethod]
        public void AddRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                roomService.AddRoom(testRoomData);

                var addedRoom = db.Rooms.ToList();

                var parsedAddedRoomNumber = int.Parse(addedRoom[0].Number);
                Assert.AreEqual(111, parsedAddedRoomNumber);
            }
        }

        [TestMethod]
        public void EditRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var roomId = roomService.AddRoom(testRoomData);
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
                var addedRoomId = roomService.AddRoom(testRoomData);

                var pickedRoom = roomService.GetRoom(addedRoomId);

                var parsedRoomPrice = double.Parse(pickedRoom.Price);
                Assert.AreEqual(300.45D, parsedRoomPrice);
            }
        }

        [TestMethod]
        public void GetRoomsTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);

                roomService.AddRoom(testRoomData);
                roomService.AddRoom(testRoomData);

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
                var addedRoomId = roomService.AddRoom(testRoomData);
                var room = roomService.GetRoom(addedRoomId);

                room.Booked = true;
                roomService.SetRoomState(room);

                Assert.AreEqual(true, room.Booked);
            }
        }

        [TestMethod]
        public void DeleteRoomTest()
        {
            using (var db = DbStorage.GetTestInstance())
            {
                var roomService = new RoomService(db);
                var addedRoomId = roomService.AddRoom(testRoomData);

                roomService.DeleteRoom(addedRoomId);

                var rooms = roomService.GetRooms();

                Assert.AreEqual(0, rooms.Count);
            }
        }
        #endregion
    }
}