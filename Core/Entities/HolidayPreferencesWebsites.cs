using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
   public class HolidayPreferencesWebsites : BaseEntity
    {

        [Required]
        public string Website { get; set; }

        public int HolidayPreferencesId { get; set; }
    }
}
