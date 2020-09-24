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
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ICollection<HolidayWebsites> Websites { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int MinPrice { get; set; }

        [Required]
        public int MaxPrice { get; set; }

    }
}
