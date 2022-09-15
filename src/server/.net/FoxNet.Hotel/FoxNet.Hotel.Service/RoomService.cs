
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxNet.Hotel.Service.DTO;
using FoxNet.Hotel.Common;

namespace FoxNet.Hotel.Service
{
    public class RoomService
    {
        private DbStorage db;
        public RoomService(DbStorage db) 
        {
            this.db = db;
        }

        public int AddRoom(RoomData roomData)
        {
            var r = new Room()
            {
                Number = roomData.Number,
                BedsAmount = roomData.BedsAmount,
                Bathroom = roomData.Bathroom,
                Booked = roomData.Booked,
                Price = roomData.Price,
            };

            var roomId = db.Rooms.Add(r);
            db.SaveChanges();

            return roomId.Entity.Id;
        }

        public void EditRoom(RoomData roomData)
        {
            var room = db.Rooms.Single(r => r.Id == roomData.Id);

            room.Number = roomData.Number;
            room.BedsAmount = roomData.BedsAmount;
            room.Price = roomData.Price;

            db.SaveChanges();
        }

        public RoomData GetRoom(int roomId)
        {
            var room = db.Rooms.Single(r => r.Id == roomId);

            return new RoomData()
            {
                Id = room.Id,
                BedsAmount = room.Number,
                Number = room.Number,
                Bathroom = room.Bathroom,
                Price = room.Price,
                Booked = room.Booked
            };
        }

        public IList<RoomData> GetRooms()
        {
            return db.Rooms.Select(r => new RoomData()
            {
                Id = r.Id,
                BedsAmount = r.BedsAmount,
                Number = r.Number,
                Booked = r.Booked,
                Price = r.Price,
                Bathroom = r.Bathroom,
            }).ToList();
        }

        public void SetRoomState(RoomData roomData)
        {
            var room = db.Rooms.Single(r => r.Id == roomData.Id);

            room.Booked = roomData.Booked;
            db.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            var room = db.Rooms.Single(r => r.Id == roomId);

            db.Rooms.Remove(room);
            db.SaveChanges();
        }
    }
}