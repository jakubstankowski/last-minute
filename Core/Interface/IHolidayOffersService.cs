﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IHolidayOffersService
    {

        public Task RefreshTuiOffersAsync();

        public Task RefreshItakaOffersAsync();

        public Task RefreshRainbowOffersAsync();

        public Task RefreshWakacjeOffersAsync();

        public Task RefreshAllOffers();

        public void ResetHolidayOffers(string website);

        public string StripHTML(string input);



    }
}
