using API.Helpers;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using API.Middleware;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<IHolidayPreferencesRepo, HolidayPreferencesRepo>();
            services.AddScoped<IHolidayOffersRepo, HolidayOffersRepo>();

            services.AddControllers();

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("LastMinuteConnection")));

            services.AddDbContext<AppIdentityDbContext>(opt => opt.UseSqlServer
               (Configuration.GetConnectionString("LastMinuteConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                     .AddEntityFrameworkStores<AppIdentityDbContext>();



            /* services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                         ValidIssuer = config["Token:Issuer"],
                         ValidateIssuer = true,
                         ValidateAudience = false
                     };
                 });*/


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
