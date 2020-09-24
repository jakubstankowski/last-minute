using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetUserPreferences()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (userId == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var preferences = await _repo.GetUserHolidayPreferencesListAsync(userId);

            return Ok(_mapper
               .Map<IEnumerable<HolidayPreferences>, IEnumerable<HolidayPreferencesToReturnDTO>>(preferences));

        }



        // GET: api/preferences/5
          [Authorize]
          [HttpGet("{id}")]
          public async Task<ActionResult<HolidayPreferencesToReturnDTO>> GetPreferencesById(int id)
          {
            var userId = HttpContext.User
             .FindFirst(ClaimTypes.NameIdentifier)
             .Value.ToString();

            var preferences = await _repo.GetUserHolidayPreferenceByIdAsync(id, userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }



            return _mapper.Map<HolidayPreferences, HolidayPreferencesToReturnDTO>(preferences);
          }



        // POST: api/HolidayPreferences
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostUserPreferencesAsync(HolidayPreferences holidayPreferences)
        {
            foreach(var website in holidayPreferences.HolidayWebsites)
            {
                System.Console.WriteLine(website.Website);
            }

           /* var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var user = await _repo.GetUserHolidayPreferences(userId);
            user.HolidayPreferences.Add(holidayPreferences);

            _userContext.SaveChanges();*/
            return Ok(200);
        }

        // PUT: api/HolidayPreferences/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, HolidayPreferencesDTO holidayPreferences)
        {



            return Ok(200);
        }

        // DELETE: api/HolidayPreferences/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayPreferences(int id)
        {
            var userId = HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value.ToString();

            var preferences = await _repo.GetUserHolidayPreferenceByIdAsync(id, userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _repo.DeleteHolidayPreference(preferences);
            _repo.SaveChanges();

            return Ok(200);
        }
    }
}
