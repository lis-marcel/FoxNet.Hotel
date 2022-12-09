using FoxNet.Hotel.Service.DTO;
using System.Diagnostics;

namespace FoxNet.Hotel.Service.ClassConverter
{
    public class ConvertRoom
    {
        public static Room RoomDataToRoom(RoomData roomData)
        {
            return new Room()
            {
                RoomNumber = roomData.RoomNumber,
                BedsAmount = roomData.BedsAmount,
                Bathroom = roomData.Bathroom,
                Price = roomData.Price,
            };
        }

        public static RoomData RoomToRoomData(Room room)
        {
            return new RoomData()
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                BedsAmount = room.BedsAmount,
                Price = room.Price,
                Bathroom = room.Bathroom
            };
        }
    }
}
