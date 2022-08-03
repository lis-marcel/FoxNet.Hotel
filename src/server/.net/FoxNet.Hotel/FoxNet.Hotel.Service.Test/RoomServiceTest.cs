using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.Test
{
    [TestClass]
    public class RoomServiceTest
    {
        /*[TestMethod]
        public void AddRoomTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

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

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void EditRoomTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

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

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void GetRoomTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

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

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void GetRoomsTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

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

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void SetRoomStateTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

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

            db.Database.EnsureDeleted();
            db.Dispose();
        }

        [TestMethod]
        public void DeleteRoomTest()
        {
            var db = new DbStorage.DbStorage();
            db.Database.EnsureCreated();

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

            db.Database.EnsureDeleted();
            db.Dispose();
        }*/
    }
}