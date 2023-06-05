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
                Beds = roomData.Beds,
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
                Beds = room.Beds,
                Price = room.Price,
                Bathroom = room.Bathroom
            };
        }
    }
}
