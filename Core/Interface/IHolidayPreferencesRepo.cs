using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayPreferencesRepo
    {
        Task<HolidayPreferences> GetHolidayPreferencesByIdAsync(int id);
        Task<HolidayPreferences> GetUserHolidayPreferenceByIdAsync(int id, string userId);
        Task<HolidayPreferences> GetUserHolidayPreferences(string id);
        Task<AppUser> GetUserWithHolidayPreferences(string id);
        public void DeleteHolidayPreference(HolidayPreferences preferences);
        bool SaveChanges();
    }
}
