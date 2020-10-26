using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Core.Entities
{
    public class HolidayPreferences : BaseEntity
    {

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public AppUser AppUser { get; set; }

        public string AppUserId { get; set; }

        [Required]
        public ICollection<HolidayPreferencesWebsites> Websites { get; set; }

    }
}
