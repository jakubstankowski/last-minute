﻿using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<HolidayOffers, HolidayOffersDTO>();
            CreateMap<HolidayPreferences, HolidayPreferencesDTO>();
            CreateMap<HolidayPreferencesWebsites, HolidayPreferencesWebsitesDTO>();
        }
    }
}
