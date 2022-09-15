using FoxNet.Hotel.BO;

namespace FoxNet.Hotel
{
    public class Room
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string? BedsAmount { get; set; }
        public string? Price { get; set; }
        public bool Bathroom { get; set; }
        public bool Booked { get; set; }
    }
}
