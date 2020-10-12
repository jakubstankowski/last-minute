using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class HolidayPreferencesRepo : IHolidayPreferencesRepo
    {
        private DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HolidayPreferencesRepo(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<HolidayPreferences> GetUserHolidayPreferenceByIdAsync(int id, string userId)
        {
            return await _context.HolidayPreferences
                .Include(h => h.Websites)
                .FirstOrDefaultAsync(u => u.AppUserId == userId && u.Id == id);

        }

        public async Task<HolidayPreferences> GetUserHolidayPreferences(string userId)
        {
            return await _context.HolidayPreferences
                .Where(h => h.AppUserId == userId)
                .Include(h => h.Websites)
                .FirstOrDefaultAsync();
        }



        public void DeleteHolidayPreference(HolidayPreferences preferences)
        {

            _context.HolidayPreferences.Remove(preferences);
        }

        public async Task<AppUser> GetUserWithHolidayPreferences(string id)
        {
            return await _userManager.Users
                  .Include(u => u.HolidayPreferences)
                  .FirstOrDefaultAsync(u => u.Id == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }




    }
}
