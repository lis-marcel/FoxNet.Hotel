using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service;
using FoxNet.Hotel.BO;
using FoxNet.Hotel.Service.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace FoxNet.Hotel.WebAPI.Controllers
{
    public class RoomsController : ControllerBase
    {
        private readonly DbStorage _context;
        private readonly RoomService _service;

        public RoomsController(DbStorage db)
        {
            _context = db;
            _service = new RoomService(_context);
        }

        [HttpPost]
        [Route("/api/rooms/add")]
        public async Task<int> AddRoom(RoomData roomData)
        {
            return _service.AddRoom(roomData);
        }

        [HttpPost]
        [Route("/api/rooms/edit")]
        public async Task EditRoom(RoomData roomData)
        {
            _service.EditRoom(roomData);
        }

        [HttpGet]
        [Route("/api/rooms/{id}")]
        public async Task<RoomData> GetRoom(int id)
        {
            return _service.GetRoom(id);
        }

        [HttpGet]
        [Route("/api/rooms")]
        public async Task<IList<RoomData>> GetRooms()
        {
            return _service.GetRooms();
        }

        [HttpPost]
        [Route("/api/rooms/search")]
        public IList<Room> GetFilteredRooms([FromBody] FiltersData roomsFilters)
        {
            return _service.GetFilteredRooms(roomsFilters);
        }

        [HttpPost]
        [Route("/api/rooms/delete/{id}")]
        public async Task DeleteRoom(int id)
        {
            _service.DeleteRoom(id);
        }
    }
}
