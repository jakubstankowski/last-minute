using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayPreferencesRepo
    {
        Task<HolidayPreferences> GetUserHolidayPreferences(string id);
        Task<AppUser> GetUserWithHolidayPreferences(string id);
        bool SaveChanges();
    }
}
