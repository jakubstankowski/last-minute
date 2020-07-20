using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LastMinute.WebAPI.App.User.Models
{
    public class User
    {
      
            public int Id { get; set; }
           
            public string Email { get; set; }

            [JsonIgnore]
            public string Password { get; set; }
        
    }
}
