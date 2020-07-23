using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.WebAPI.App.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LastMinute.WebAPI.App.Auth.Infrastructure
{
    public class AuthContext :  IdentityDbContext<ApplicationUser>
    {
        public AuthContext(DbContextOptions opt) : base(opt)
        {

        }

    }
}
