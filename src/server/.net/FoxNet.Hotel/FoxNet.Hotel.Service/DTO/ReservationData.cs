using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.DTO
{
    public class ReservationData
    {
        public int Id { get; set; }
        public DateOnly FirstDay { get; set; }
        public DateOnly LastDay { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }
}
