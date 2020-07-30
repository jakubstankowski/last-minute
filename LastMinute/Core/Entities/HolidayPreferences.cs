using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
   public  class HolidayPreferences : BaseEntity
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int MinPrice { get; set; }

        [Required]
        public int MaxPrice { get; set; }
    }
}
