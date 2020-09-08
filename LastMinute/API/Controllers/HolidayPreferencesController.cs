using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using API.Extenions;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class HolidayPreferencesController : ControllerBase
    {
        private readonly AppIdentityDbContext _userContext;
        private readonly UserManager<AppUser> _userManager;
        private IHolidayPreferencesRepo _repo;
        private readonly IMapper _mapper;

        public HolidayPreferencesController(IHolidayPreferencesRepo repo, IMapper mapper, UserManager<AppUser> userManager, AppIdentityDbContext userContext)
        {
            _userContext = userContext;
            _userManager = userManager;
            _repo = repo;
            _mapper = mapper;
        }


        // GET: api/HolidayPreferences

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayPreferences>>> GetUserPreferences()
        {
            var userId = HttpContext.FindByIdFromClaimsPrinciple();

            if (userId == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var preferences = await _repo.GetUserHolidayPreferencesAsync(userId);

            return Ok(_mapper
               .Map<IEnumerable<HolidayPreferences>, IEnumerable<HolidayPreferencesToReturnDTO>>(preferences));

        }



        /*  // GET: api/preferences/5
          [HttpGet("{id}")]
          public async Task<ActionResult<HolidayPreferencesToReturnDTO>> GetPreferencesById(int id)
          {
              var preferences = await _repo.GetHolidayPreferenceByIdAsync(id);
              if (preferences == null)
              {
                  return NotFound(new ApiResponse(404));
              }

              return _mapper.Map<HolidayPreferences, HolidayPreferencesToReturnDTO>(preferences);
          }*/



        // POST: api/HolidayPreferences
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostAsync(HolidayPreferences holidayPreferences)
        {
            /*var userId = await _userManager.FindByIdAsync(holidayPreferences.AppUserId);
            Console.WriteLine(user.HolidayPreferences);

            foreach(HolidayPreferences preference2 in user.HolidayPreferences)
            {
                Console.WriteLine(preference2);
            }
            Console.WriteLine(user.Id);*/
            /*  var userContext = _userContext.Users.ToList();

              var preferences = _userContext.Users.Include(h => h.HolidayPreferences).FirstOrDefault(us => us.Id == user.Id).HolidayPreferences;
              //Console.WriteLine(preferences.Id);

              foreach(HolidayPreferences preference in preferences)
              {
                  Console.WriteLine(preference.Title);      
              }*/


            // Object reference not set to an instance of an object.

            // user.HolidayPreferences.Add(holidayPreferences);


            /* _repo.CreateHolidayPreference(holidayPreferences);
             _repo.SaveChanges();*/

            return Ok();
        }

        // PUT: api/HolidayPreferences/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
