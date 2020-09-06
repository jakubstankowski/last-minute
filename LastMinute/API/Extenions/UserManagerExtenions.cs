using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extenions
{
    public static class UserManagerExtenions
    {

        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
        public static string FindByIdFromClaimsPrinciple(this HttpContext context)
        {
            if(context.User == null)
            {
                return "nima";
            }

            return context.User.Claims.Single(u => u.Type == "id").Value;

        }


      


    }
}
