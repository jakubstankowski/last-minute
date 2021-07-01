using API.Helpers;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using API.Middleware;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Configuration;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using WorkerService;
using System;

namespace API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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
            services.AddScoped<IHolidayPreferencesWebsites, HolidayPreferencesWebsiteRepo>();
            services.AddScoped<IHolidayOffersService, HolidayOffersService>();




            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:4200")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });


            services.AddControllers();

            services.AddDbContext<DataContext>(opt =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                string connStr;


                if (env == "Development")
                {
                    connStr = Configuration.GetConnectionString("LastMinuteConnection");
                }
                else
                {
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                    connUrl = connUrl.Replace("postgress://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];

                    connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}; SSL Mode=Require; Trust Server Certificate=true";

                    Console.WriteLine("connStr: " + connStr);

                }
                opt.UseNpgsql(connStr);
            }


            );

            /*services.AddDbContext<DataContext>(opt =>
           opt.UseNpgsql(
               Configuration.GetConnectionString("LastMinuteConnection")));*/


            services.AddIdentity<AppUser, IdentityRole>()
                     .AddEntityFrameworkStores<DataContext>()
                      .AddSignInManager<SignInManager<AppUser>>();


            var jwtSection = Configuration.GetSection("JwtBearerTokenSettings");
            services.Configure<JwtBearerTokenSettings>(jwtSection);
            var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
            });
            services.AddAuthentication(
     CertificateAuthenticationDefaults.AuthenticationScheme)
        .AddCertificate();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            /*app.UseHttpsRedirection();*/

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);


            /*  app.Use(async (context, next) =>

               {

                   await next();

                   if (context.Response.StatusCode == 404 && !System.IO.Path.HasExtension(context.Request.Path.Value))

                   {

                       context.Request.Path = "/index.html";

                       await next();

                   }

               });*/

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}