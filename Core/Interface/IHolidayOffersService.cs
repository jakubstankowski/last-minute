using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayOffersService
    {
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreference(IEnumerable<HolidayOffers> holidayOffers, HolidayPreferences holidayPreferences);


    }
}
