using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
   public  class HolidayPreferences : BaseEntity
    {
        [Key]
        [Required]
        public string Id { get; set; }

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
