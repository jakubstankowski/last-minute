using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Services
{
    public class HolidayOffersService : IHolidayOffersService
    {
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreferences(IEnumerable<HolidayOffers> holidayOffers, HolidayPreferences holidayPreference)
        {

            return holidayOffers
                    .Where(o => o.Price >= holidayPreference.MinPrice && o.Price <= holidayPreference.MaxPrice)
                    .ToList();
        }
    }
}
