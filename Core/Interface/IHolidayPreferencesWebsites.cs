using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayPreferencesWebsites
    {
        public void DeleteHolidayPreferenceWebsite(HolidayPreferencesWebsites holidayPreferencesWebsites);
        public bool SaveChanges();

    }
}
