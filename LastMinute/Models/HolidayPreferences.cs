using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastMinute.Models
{
    public class HolidayPreferences
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Country { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }
    }
}
