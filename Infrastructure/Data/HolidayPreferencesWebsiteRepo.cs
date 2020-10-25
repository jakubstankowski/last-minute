using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data
{
    class HolidayPreferencesWebsiteRepo : IHolidayPreferencesWebsites
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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
