using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Models;

namespace LastMinute.Data
{
    public interface IHolidayPreferencesRepo
    {
        IEnumerable<HolidayPreferences> GetAllHolidayPreferences();
        HolidayPreferences GetHolidayPreferenceById(int id);
        void CreateHolidayPreference(HolidayPreferences preference);
        void UpdateHolidayPreference(HolidayPreferences preference);
        void DeleteHolidayPreference(HolidayPreferences preference);

    }
}
