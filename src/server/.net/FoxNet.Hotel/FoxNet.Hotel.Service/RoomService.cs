using FoxNet.Hotel.Service.DTO;
using FoxNet.Hotel.Service.Filters;
using FoxNet.Hotel.Common;
using Microsoft.EntityFrameworkCore;
using FoxNet.Hotel.Service.ClassConverter;
using Microsoft.Data.Sqlite;

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
                RoomNumber = roomData.RoomNumber,
                BedsAmount = roomData.BedsAmount,
                Bathroom = roomData.Bathroom,
                Price = roomData.Price,
            };

            var roomId = db.Rooms.Add(r);
            db.SaveChanges();

            return roomId.Entity.RoomId;
        }

        public void EditRoom(RoomData roomData)
        {
            var room = db.Rooms.Single(r => r.RoomId == roomData.RoomId);

            var editedRoomData = ConvertRoom.RoomDataToRoom(roomData);

            room = editedRoomData;

            db.SaveChanges();
        }

        public RoomData GetRoom(int roomId)
        {
            var room = db.Rooms.Single(r => r.RoomId == roomId);

            return new RoomData()
            {
                RoomId = room.RoomId,
                BedsAmount = room.BedsAmount,
                RoomNumber = room.RoomNumber,
                Bathroom = room.Bathroom,
                Price = room.Price,
            };
        }

        public IList<RoomData> GetRooms()
        {
            return db.Rooms.Select(r => new RoomData()
            {
                RoomId = r.RoomId,
                BedsAmount = r.BedsAmount,
                RoomNumber = r.RoomNumber,
                Price = r.Price,
                Bathroom = r.Bathroom,
            }).ToList();
        }

        public IList<Room> GetFilteredRooms(DTO.FiltersData roomsFilters)
        {
            return Filters.FiltersQueries.FilterRooms(db, roomsFilters);
        }

        public void DeleteRoom(int roomId)
        {
            var room = db.Rooms.Single(r => r.RoomId == roomId);

            db.Rooms.Remove(room);
            db.SaveChanges();
        }
    }
}