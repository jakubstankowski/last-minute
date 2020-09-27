using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HolidayPreferences : BaseEntity
    {


       
        public int MinPrice { get; set; }

       
        public int MaxPrice { get; set; }

        public AppUser AppUser { get; set; }

        public string AppUserId { get; set; }

        [Required]
        public ICollection<HolidayWebsites> Websites { get; set; }


        public HolidayPreferences()
        {
            MinPrice = 0;
            MaxPrice = 2500;
        }
    }
}
