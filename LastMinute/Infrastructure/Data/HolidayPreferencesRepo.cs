using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Data
{
    public class HolidayPreferencesRepo : IHolidayPreferencesRepo
    {
        public Task<HolidayPreferences> GetHolidayPreferenceByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<HolidayPreferences>> GetHolidayPreferencesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
