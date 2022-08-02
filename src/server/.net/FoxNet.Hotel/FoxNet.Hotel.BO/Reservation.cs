using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.BO
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }
}
