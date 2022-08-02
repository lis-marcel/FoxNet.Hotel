using FoxNet.Hotel.BO;

namespace FoxNet.Hotel
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BedsAmount { get; set; }
        public float Price { get; set; }
        public bool Bathroom { get; set; }
        public bool Booked { get; set; }
    }
}
