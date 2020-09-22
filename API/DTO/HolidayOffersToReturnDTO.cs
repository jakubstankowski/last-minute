using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class HolidayOffersToReturnDTO
    {

        public int Id { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
        public string Url { get; set; }

    }
}
