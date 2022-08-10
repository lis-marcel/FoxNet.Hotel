using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service;
using FoxNet.Hotel.Service.DTO;

namespace FoxNet.Hotel.WebAPI.Controllers
{
    public class ReservationsController : ControllerBase
    {
        private readonly DbStorage _context;
        private readonly ReservationService _service;

        public ReservationsController(DbStorage db)
        {
            _context = db;
            _service = new ReservationService(_context);
        }

        [HttpPost]
        [Route("/api/reservations/add")]
        public async Task<int> MakeReservations(ReservationData reservationData)
        {
            return _service.MakeReservation(reservationData);
        }

        [HttpGet]
        [Route("/api/reservations/{id}")]
        public async Task<ReservationData> GetReservaion(int id)
        {
            return _service.GetReservation(id);
        }

        [HttpGet]
        [Route("/api/reservations/{id}")]
        public async Task<IList<ReservationData>> GetReservaions()
        {
            return _service.GetReservations();
        }

        [HttpPost]
        [Route("/api/reservations/delete")]
        public async Task DeleteReservation(int id)
        {
            _service.DeleteReservation(id);
        }
    }
}
