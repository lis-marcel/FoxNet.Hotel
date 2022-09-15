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
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Birth { get; set; }
        public int Phone { get; set; }
        public string? Email { get; set; }
        public Type AccountType { get; set; }
        public string? Password { get; set; }
        public float Money { get; set; }
    }
}
