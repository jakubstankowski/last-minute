using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LastMinute.WebAPI.App.Auth.Infrastructure
{
    public class AuthContext :  IdentityDbContext<IdentityUser>
    {
        public AuthContext(DbContextOptions opt) : base(opt)
        {

        }

    }
}
