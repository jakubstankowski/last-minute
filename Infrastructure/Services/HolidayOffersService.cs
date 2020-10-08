﻿using System.Collections.Generic;
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
    }
}
