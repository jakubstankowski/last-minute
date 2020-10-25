using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayPreferencesWebsites
    {
        public void DeleteHolidayPreferenceWebsite(HolidayPreferencesWebsites holidayPreferencesWebsites);

        public Task<HolidayPreferencesWebsites> GetHolidayPreferencesWebsitesByIdAsync(int id);
        
        public bool SaveChanges();

    }
}
