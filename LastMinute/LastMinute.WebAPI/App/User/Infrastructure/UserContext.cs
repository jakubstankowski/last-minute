using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.WebAPI.App.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LastMinute.WebAPI.App.User.Infrastructure
{
    public class UserContext : IdentityDbContext<IdentityUser>
    {

        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {

        }

        public DbSet<UserDetails> User { get; set; }

    }
}
