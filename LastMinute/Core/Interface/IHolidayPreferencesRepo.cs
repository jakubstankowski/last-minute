using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
   public interface IHolidayPreferencesRepo
    {

        Task<HolidayPreferences> GetHolidayPreferenceByIdAsync(int id);
        Task<IEnumerable<HolidayPreferences>> GetUserHolidayPreferencesAsync(string id);

        void CreateUserHolidayPreference(HolidayPreferences preference);
        public void DeleteHolidayPreference(HolidayPreferences preferences);

        bool SaveChanges();
    }
}
