using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.DTO
{
    public class RoomData
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string? BedsAmount { get; set; }
        public string? Price { get; set; }
        public bool Bathroom { get; set; }
        public bool Booked { get; set; }
    }
}
