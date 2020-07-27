using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Data;
using LastMinute.Models;

namespace LastMinute.WebAPI.Infrastructure
{
    public class HolidayPreferencesRepo : IHolidayPreferencesRepo
    {
        private readonly DataContext _context;

        public HolidayPreferencesRepo(DataContext context)
        {
            _context = context;

        }



        public void CreateHolidayPreference(HolidayPreferences preference)
        {
            if (preference == null)
            {
                throw new ArgumentNullException(nameof(preference));
            }

            _context.HolidayPreferences.Add(preference);
        }

        public void DeleteHolidayPreference(HolidayPreferences preference)
        {
            _context.HolidayPreferences.Remove(preference);
        }

        public IEnumerable<HolidayPreferences> GetAllHolidayPreferences()
        {
            return _context.HolidayPreferences.ToList();
        }

        public HolidayPreferences GetHolidayPreferenceById(int id)
        {
            return _context.HolidayPreferences.FirstOrDefault(v => v.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateHolidayPreference(HolidayPreferences preference)
        {
            _context.Update(preference);
        }
    }
}
