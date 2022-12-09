namespace FoxNet.Hotel.Service.DTO
{
    public class RoomData
    {
        public int RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public string? BedsAmount { get; set; }
        public string? Price { get; set; }
        public bool Bathroom { get; set; }
    }
}
