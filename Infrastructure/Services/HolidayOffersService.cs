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
                .OrderBy(o => o.Price)
                .ToList();
            /* List<HolidayOffers> offers = new List<HolidayOffers>();

             foreach(var website in holidayPreference.Websites)
             {
                 Console.WriteLine("website: "+ website.Website);
                 offers = holidayOffers
                     .Where(o => o.Website == website.Website)
                     .Where(o => o.Price >= holidayPreference.MinPrice && o.Price <= holidayPreference.MaxPrice)
                     .OrderBy(o => o.Price)
                     .ToList();
             }

             return offers;*/

            /* return holidayOffers
                     .Where(o => o.Price >= holidayPreference.MinPrice && o.Price <= holidayPreference.MaxPrice)
                     .OrderBy(o => o.Price)
                     .ToList();*/


        }
    }
}
