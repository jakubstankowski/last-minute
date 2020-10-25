using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data
{
    public class HolidayPreferencesWebsiteRepo : IHolidayPreferencesWebsites
    {
        private readonly DataContext _context;

        public HolidayPreferencesWebsiteRepo(DataContext context)
        {
            _context = context;
        }


        public void DeleteHolidayPreferenceWebsite(HolidayPreferencesWebsites holidayPreferencesWebsites)
        {
            _context.HolidayPreferencesWebsites.Remove(holidayPreferencesWebsites);
        }

        public async Task<HolidayPreferencesWebsites> GetHolidayPreferencesWebsitesByIdAsync(int id)
        {
            return await _context.HolidayPreferencesWebsites.FindAsync(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
