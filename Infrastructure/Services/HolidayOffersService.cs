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
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreferences(IEnumerable<HolidayOffers> holidayOffers, IEnumerable<HolidayPreferences> holidayPreferences)
        {
            List<HolidayOffers> foundOffers = new List<HolidayOffers>();


            foreach(var preference in holidayPreferences)
            {
               var foundOffer =  holidayOffers.Where(o => o.Country == preference.Country).ToList();
               
            }
            
            throw new NotImplementedException();
        }
    }
}
