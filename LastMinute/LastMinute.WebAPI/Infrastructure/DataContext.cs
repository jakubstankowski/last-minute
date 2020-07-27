using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Models;
using LastMinute.WebAPI.App.User.Models;
using Microsoft.EntityFrameworkCore;

namespace LastMinute.WebAPI.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<HolidayPreferences> HolidayPreferences { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }




    }
}
