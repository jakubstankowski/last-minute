using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTO
{
    public class HolidayPreferencesDTO
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public ICollection<HolidayWebsites> Websites { get; set; }
    }
}
