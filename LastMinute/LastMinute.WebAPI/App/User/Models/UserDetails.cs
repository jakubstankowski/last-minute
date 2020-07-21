using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LastMinute.WebAPI.App.User.Models
{
    public class UserDetails
    {

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
