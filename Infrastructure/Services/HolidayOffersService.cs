using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Services
{
    public class HolidayOffersService : IHolidayOffersService
    {
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreferences(IEnumerable<HolidayOffers> holidayOffers, IEnumerable<HolidayPreferences> holidayPreferences)
        {
           
            foreach(var preference in holidayPreferences)
            {

            }
            
            throw new NotImplementedException();
        }
    }
}
