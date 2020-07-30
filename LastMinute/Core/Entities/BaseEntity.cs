using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
   public class BaseEntity 
    {
        [Key]
        [Required]
        public string Id { get; set; }
    }
}
