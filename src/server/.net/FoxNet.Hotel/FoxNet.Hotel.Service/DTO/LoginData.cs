using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.DTO
{
    public class LoginData
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public Guid? SessionGuid { get; set; }
    }
}
