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
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class HolidayPreferencesController : ControllerBase
    {
        private IHolidayPreferencesRepo _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public HolidayPreferencesController(IHolidayPreferencesRepo repo, IMapper mapper, AppIdentityDbContext userContext, UserManager<AppUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }


        // GET: api/HolidayPreferences

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<HolidayPreferencesDTO>> GetUserPreferences()
        {
            var userId = HttpContext.User
             .FindFirst(ClaimTypes.NameIdentifier)
             .Value.ToString();

            var preferences = await _repo.GetUserHolidayPreferences(userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<HolidayPreferences, HolidayPreferencesDTO>(preferences);

        }


        //PUT: api/HolidayPreferences
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostUserPreferences(HolidayPreferences holidayPreferences)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _repo.GetUserWithHolidayPreferences(userId);

            user.HolidayPreferences = holidayPreferences;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<HolidayPreferences, HolidayPreferencesDTO>(holidayPreferences));
            }


            return BadRequest("Problem with add new preferences");
        }

        // PUT: api/HolidayPreferences/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutHolidayPreference(HolidayPreferences updatePreference)
        {
            var userId = HttpContext.User
               .FindFirst(ClaimTypes.NameIdentifier)
               .Value.ToString();

            var preferences = await _repo.GetUserHolidayPreferences(userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            preferences.MinPrice = updatePreference.MinPrice;
            preferences.MaxPrice = updatePreference.MaxPrice;
            preferences.Websites = updatePreference.Websites;

            _repo.SaveChanges();

            return Ok(_mapper.Map<HolidayPreferences, HolidayPreferencesDTO>(preferences));
        }

        // DELETE: api/HolidayPreferences/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayPreferences(int id)
        {
            var userId = HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value.ToString();

            var preference = await _repo.GetUserHolidayPreferenceByIdAsync(id, userId);

            if (preference == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _repo.DeleteHolidayPreference(preference);
            _repo.SaveChanges();

            return Ok(200);
        }
    }
}
