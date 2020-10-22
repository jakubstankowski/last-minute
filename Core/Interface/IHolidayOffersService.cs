using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayOffersService
    {
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreference(IEnumerable<HolidayOffers> holidayOffers, HolidayPreferences holidayPreferences);

        public Task RefreshTuiOffersAsync();

        public Task RefreshItakaOffersAsync();

        public Task RefreshRainbowOffersAsync();

        public Task RefreshWakacjeOffersAsync();

        
    }
}
