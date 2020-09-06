using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<HolidayPreferences> HolidayPreferences { get; set; }

        public DbSet<HolidayOffers> HolidayOffers { get; set; }

      /*  public DbSet<AppUser> AppUser { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HolidayPreferences>()
                .HasOne(p => p.AppUser)
                .WithMany(b => b.HolidayPreferences);
        }
    }
}
