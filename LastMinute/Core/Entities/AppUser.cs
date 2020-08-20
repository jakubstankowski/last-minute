using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    class AppUser : IdentityUser
    {
        public HolidayPreferences HolidayPreferences { get; set; }

    }
}
