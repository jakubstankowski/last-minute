using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class HolidayPreferencesRepo : IHolidayPreferencesRepo
    {
        private DataContext _context;

        public HolidayPreferencesRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<HolidayPreferences> GetHolidayPreferenceByIdAsync(int id)
        {
            return await _context.HolidayPreferences.FindAsync(id);
        }

        public async Task<IReadOnlyList<HolidayPreferences>> GetHolidayPreferencesAsync()
        {
            return await _context.HolidayPreferences.ToListAsync();
        }

      
        public void CreateHolidayPreference(HolidayPreferences preference)
        {
            _context.HolidayPreferences.Add(preference);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
