using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxNet.Hotel.Service.DTO
{
    public class FiltersData
    {
        public string? FirstDay { get; set; }
        public string? LastDay { get; set; }
        public string? MaxPrice { get; set; }
        public string? MinPrice { get; set; }
        public string? Beds { get; set; }
    }
}
