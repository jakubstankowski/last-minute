using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Models;
using Microsoft.AspNetCore.Identity;

namespace LastMinute.WebAPI.App.User.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<HolidayPreferences> HolidayPreferences { get; set; }

    }
}
