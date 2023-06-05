using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.DTO
{
    public enum Type
    {
        Admin, Worker, Client
    }

    public class UserData
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public DateOnly Birth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Type AccountType { get; set; }
        public string? Password { get; set; }
    }
}
