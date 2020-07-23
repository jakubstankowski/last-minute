using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Models;
using Microsoft.AspNetCore.Identity;

namespace LastMinute.WebAPI.App.User.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Password { get; set; }
       /* public string UserName { get; set; }

        public string Email { get; set; }*/

        public ICollection<HolidayPreferences> HolidayPreferences { get; set; }

    }
}
