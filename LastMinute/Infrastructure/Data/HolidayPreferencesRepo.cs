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

        public async Task<HolidayPreferences> GetHolidayPreferenceByIdAsync(int id)
        {
            return await _context.HolidayPreferences.FindAsync(id);
        }

        public async Task<IEnumerable<HolidayPreferences>> GetUserHolidayPreferencesListAsync(string userId)
        {
            return await _context.HolidayPreferences
                .Where(h => h.AppUserId == userId)
                .ToListAsync();
        }

     
        public  void CreateUserHolidayPreference(HolidayPreferences preference)
        {
             _context.HolidayPreferences.Add(preference);
        }

        public void DeleteHolidayPreference(HolidayPreferences preferences)
        {
            _context.HolidayPreferences.Remove(preferences);
        }

        public async Task<AppUser> GetUserHolidayPreferences(string id)
        {
          return  await _userManager.Users
                .Where(u => u.Id == id)
                .Include(u => u.HolidayPreferences)
                .FirstOrDefaultAsync();
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    

      
    }
}
