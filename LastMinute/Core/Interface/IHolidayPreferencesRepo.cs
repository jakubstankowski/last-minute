using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
   public interface IHolidayPreferencesRepo
    {

        Task<HolidayPreferences> GetUserHolidayPreferenceByIdAsync(int id, string userId);
        Task<IEnumerable<HolidayPreferences>> GetUserHolidayPreferencesListAsync(string id);
        Task<AppUser> GetUserHolidayPreferences(string id);
        public void DeleteHolidayPreference(HolidayPreferences preferences);
        bool SaveChanges();
    }
}
