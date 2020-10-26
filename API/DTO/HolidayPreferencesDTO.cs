﻿using System.Collections.Generic;

namespace API.DTO
{
    public class HolidayPreferencesDTO
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public ICollection<HolidayPreferencesWebsitesDTO> Websites { get; set; }
    }
}
