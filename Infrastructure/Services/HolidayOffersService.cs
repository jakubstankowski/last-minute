using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Services
{
    public class HolidayOffersService : IHolidayOffersService
    {
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreferences(IEnumerable<HolidayPreferences> holidayPreferences)
        {
            var preferences = holidayPreferences;
            
            throw new NotImplementedException();
        }
    }
}
