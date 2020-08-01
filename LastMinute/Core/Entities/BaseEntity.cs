using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BaseEntity 
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
