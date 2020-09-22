using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<HolidayPreferences> HolidayPreferences { get; set; }

    }
}
