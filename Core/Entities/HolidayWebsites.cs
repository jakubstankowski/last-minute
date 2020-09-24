using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
   public class HolidayWebsites : BaseEntity
    {
        public string Website { get; set; }
/*
        public HolidayPreferences HolidayPreferences { get; set; }*/

        public int HolidayPreferencesId { get; set; }
    }
}
