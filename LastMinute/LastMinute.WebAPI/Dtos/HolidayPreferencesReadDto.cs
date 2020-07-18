using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastMinute.WebAPI.Dtos
{
    public class HolidayPreferencesReadDto
    {

        public int Id { get; set; }

        public string Website { get; set; }


        public string Country { get; set; }


        public int MinPrice { get; set; }


        public int MaxPrice { get; set; }

    }
}
