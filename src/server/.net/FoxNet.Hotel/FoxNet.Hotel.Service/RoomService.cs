
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.Service
{
    public class RoomService
    {
        public RoomService() { }
        public RoomService(DbStorage.DbStorage db) { }

        public int AddRoom(RoomData roomData)
        {
            var db = new DbStorage.DbStorage();

            db.Database.EnsureCreated();

            var room = new Room()
            {
                Number = roomData.Number,
                BedsAmount = roomData.BedsAmount,
                Bathroom = roomData.Bathroom,
                Booked = roomData.Booked,
                Price = roomData.Price,
            };

            var roomId = db.Rooms.Add(room);
            db.SaveChanges();

            db.Dispose();

            return roomId.Entity.Id;
        }

        public void EditRoom(RoomData roomData)
        {
            var db = new DbStorage.DbStorage();
            var room = db.Rooms.SingleOrDefault(r => r.Id == roomData.Id);

            db.Database.EnsureCreated();

            if (room != null)
            {
                room.Number = roomData.Number;
                room.BedsAmount = roomData.BedsAmount;
                room.Price = roomData.Price;

                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }

        public RoomData GetRoom(int roomId)
        {
            var db = new DbStorage.DbStorage();
            var room = db.Rooms.SingleOrDefault(r => r.Id == roomId);

            db.Database.EnsureCreated();

            if (room != null)
            {
                var r = new RoomData()
                {
                    Id = room.Id,
                    BedsAmount = room.BedsAmount,
                    Number = room.Number,
                    Bathroom = room.Bathroom,
                    Price = room.Price,
                    Booked = room.Booked
                };

                db.Dispose();
                return r;
            }

            else
            {
                db.Dispose();
                return null;
            }
        }

        public IList<RoomData> GetRooms()
        {
            var db = new DbStorage.DbStorage();
            var rooms = new List<RoomData>();

            db.Database.EnsureCreated();

            foreach (var r in db.Rooms)
            {
                var room = new RoomData()
                {
                    Id = r.Id,
                    BedsAmount = r.BedsAmount,
                    Number = r.Number,
                    Booked = r.Booked,
                    Price = r.Price,
                    Bathroom = r.Bathroom,
                };

                rooms.Add(room);
            }

            db.Dispose();

            return rooms;
        }

        public void SetRoomState(RoomData roomData)
        {
            var db = new DbStorage.DbStorage();
            var room = db.Rooms.SingleOrDefault(r => r.Id == roomData.Id);

            db.Database.EnsureCreated();

            if (room != null)
            {
                room.Booked = roomData.Booked;
                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }

        public void DeleteRoom(int roomId)
        {
            var db = new DbStorage.DbStorage();
            var room = db.Rooms.SingleOrDefault(r => r.Id == roomId);

            db.Database.EnsureCreated();

            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }

            else db.SaveChanges();

            db.Dispose();
        }
    }
}