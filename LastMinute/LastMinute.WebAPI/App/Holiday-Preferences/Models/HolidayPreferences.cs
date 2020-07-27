using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.WebAPI.App.User.Models;
using Microsoft.AspNetCore.Identity;

namespace LastMinute.Models
{
    public class HolidayPreferences
    {

        [Key]
        [Required]
        public int Id { get; set; }


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

        [Required]
        public string UserId { get; set; }

       
        public ApplicationUser User { get; set; }
    }
}
