using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class HolidayOffers : BaseEntity
    {
        [Required]
         public string Title { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Url { get; set; }

     

    }
}
