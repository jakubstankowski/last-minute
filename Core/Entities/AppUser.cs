using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class AppUser : IdentityUser
    {
        public HolidayPreferences HolidayPreferences { get; set; }

    }
}
