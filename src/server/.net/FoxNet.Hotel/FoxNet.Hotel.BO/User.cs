using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel
{
    public enum Type 
    { 
        Admin, Worker, Client
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly Birth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Type AccountType { get; set; }
        public string? Password { get; set; }
        public string? Money { get; set; }
    }
}
