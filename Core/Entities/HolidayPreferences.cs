using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class HolidayPreferences : BaseEntity
    {


        public HolidayPreferences()
        {
           
        }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public AppUser AppUser { get; set; }

        public string AppUserId { get; set; }

        [Required]
        public ICollection<HolidayPreferencesWebsites> Websites { get; set; }

    }
}
