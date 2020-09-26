using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTO
{
    public class HolidayPreferencesToReturnDTO
    {
       
        public ICollection<HolidayWebsites> Websites { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

    }
}
