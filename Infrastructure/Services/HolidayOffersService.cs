using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace Infrastructure.Services
{
    public class HolidayOffersService : IHolidayOffersService
    {
        public IEnumerable<HolidayOffers> GetHolidayOffersByUserHolidayPreference(IEnumerable<HolidayOffers> holidayOffers, HolidayPreferences holidayPreference)
        {
            List<HolidayOffers> offers = new List<HolidayOffers>();



            foreach (var website in holidayPreference.Websites)
            {
                foreach (var offer in holidayOffers)
                {
                    if(offer.Website == website.Website && offer.Price >= holidayPreference.MinPrice && offer.Price <= holidayPreference.MaxPrice)
                    {
                         offers.Add(offer);
                    }
                }
            }

            return offers;

        }

        public Task RefreshItakaOffersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RefreshRainbowOffersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RefreshTuiOffersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RefreshWakacjeOffersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
