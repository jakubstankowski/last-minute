using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Models;

namespace LastMinute.Data
{
    public class MockHolidayPreferencesRepo : IHolidayPreferencesRepo
    {
        public void CreateHolidayPreference(HolidayPreferences preference)
        {
            throw new NotImplementedException();
        }

        public void DeleteHolidayPreference(HolidayPreferences preference)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HolidayPreferences> GetAllHolidayPreferences()
        {
            var holidayPreferences = new List<HolidayPreferences>
            {
                new HolidayPreferences{Id=0, Country= "Poland", Title="First holiday", MinPrice = 1000, MaxPrice = 2000, Website = "r.pl"},
                new HolidayPreferences{Id=1, Country= "Bulgaria", Title="First holiday", MinPrice = 1000, MaxPrice = 2000, Website = "itaka.pl"}
            };

            return holidayPreferences;
        }

        public HolidayPreferences GetHolidayPreferenceById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHolidayPreference(HolidayPreferences preference)
        {
            throw new NotImplementedException();
        }
    }
}
