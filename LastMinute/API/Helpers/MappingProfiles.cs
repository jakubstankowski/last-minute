using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {

        public MappingProfiles()
        {
            CreateMap<HolidayOffers, HolidayOffersToReturnDTO>();
            CreateMap<HolidayPreferences, HolidayPreferencesToReturnDTO>();
        }
    }
}
