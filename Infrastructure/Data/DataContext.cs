using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<HolidayPreferences> HolidayPreferences { get; set; }

        public DbSet<HolidayOffers> HolidayOffers { get; set; }

        public DbSet<HolidayPreferencesWebsites> HolidayPreferencesWebsites { get; set; }

    }
}
