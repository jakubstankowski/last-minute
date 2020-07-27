using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.WebAPI.App.User.Models;

namespace LastMinute.WebAPI.Infrastructure
{
   public  interface IAuthRepository
    {
        Task<ApplicationUser> Register(ApplicationUser user, string password);
        Task<ApplicationUser> Login(string username, string password);

    }
}
