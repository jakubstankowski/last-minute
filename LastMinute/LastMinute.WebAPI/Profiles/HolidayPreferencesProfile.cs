using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LastMinute.Models;
using LastMinute.WebAPI.Dtos;

namespace LastMinute.WebAPI.Profiles
{
    public class HolidayPreferencesProfile : Profile
    {

        public HolidayPreferencesProfile()
        {
            CreateMap<HolidayPreferences, HolidayPreferencesReadDto>();

        }
    }
}
