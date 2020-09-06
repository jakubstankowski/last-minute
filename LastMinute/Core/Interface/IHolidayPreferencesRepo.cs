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
        Task<HolidayPreferences[]> GetHolidayPreferencesAsync(string id);

        void CreateHolidayPreference(HolidayPreferences preference);

        bool SaveChanges();
    }
}
