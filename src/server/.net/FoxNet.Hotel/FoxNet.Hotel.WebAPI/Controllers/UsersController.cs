using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoxNet.Hotel.Common;
using FoxNet.Hotel.Service;
using FoxNet.Hotel.Service.DTO;
using System.Drawing;

namespace FoxNet.Hotel.WebAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DbStorage _context;
        private readonly UserService _service;

        public UsersController(DbStorage db)
        {
            _context = db;
            _service = new UserService(_context);
        }

        [HttpPost]
        [Route("/api/users/add")]
        public async Task<int> AddUser(UserData userData)
        {
            return _service.AddUser(userData);
        }

        [HttpPost]
        [Route("/api/users/login")]
        public async Task<string> LoginUser(LoginData loginData)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginData.email);

            var requestPassword = loginData.password;
            var userPassword = user.Password;

            bool equal = PasswordService.ComparePasswords(userPassword, requestPassword);

            if (user != null && equal)
            {
                string sessionGuid = Guid.NewGuid().ToString();

                return sessionGuid;
            }

            else
            {
                return "Error";
            }
        }

        [HttpPost]
        [Route("api/users/edit")]
        public async Task EditUser(UserData userData)
        {
            _service.EditUser(userData);
        }

        [HttpGet]
        [Route("/api/users")]
        public async Task<IList<UserData>> GetUsers()
        {
            var users = _service.GetUsers();

            return users;
        }

        [HttpGet]
        [Route("/api/users/{id}")]
        public async Task<UserData> GetUser(int id)
        {
            return _service.GetUser(id);
        }

        [HttpPost]
        [Route("/api/users/delete/{id}")]
        public async Task DeleteUser(int id)
        {
            _service.DeleteUser(id);
        }
    }
}
