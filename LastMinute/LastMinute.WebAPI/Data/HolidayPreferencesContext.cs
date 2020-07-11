using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Models;
using Microsoft.EntityFrameworkCore;

namespace LastMinute.Data
{
    public class HolidayPreferencesContext : DbContext
    {
        public HolidayPreferencesContext(DbContextOptions<HolidayPreferencesContext> opt) : base(opt)
        {

        }

        public DbSet<HolidayPreferences> HolidayPreferences { get; set; }
    }
}
