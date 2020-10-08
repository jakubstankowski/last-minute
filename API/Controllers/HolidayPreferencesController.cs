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
        public async Task<IActionResult> GetUserPreferences()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (userId == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var preferences = await _repo.GetUserHolidayPreferencesListAsync(userId);

            return Ok(_mapper
               .Map<IEnumerable<HolidayPreferences>, IEnumerable<HolidayPreferencesDTO>>(preferences));

        }



        // GET: api/preferences/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayPreferencesDTO>> GetPreferencesById(int id)
        {
            var userId = HttpContext.User
             .FindFirst(ClaimTypes.NameIdentifier)
             .Value.ToString();

            var preferences = await _repo.GetUserHolidayPreferenceByIdAsync(id, userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<HolidayPreferences, HolidayPreferencesDTO>(preferences);
        }



        //PUT: api/HolidayPreferences
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostUserPreferencesAsync(HolidayPreferences holidayPreferences)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _repo.GetUserHolidayPreferences(userId);

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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHolidayPreference(int id, HolidayPreferencesDTO preferenceDTO)
        {
            var userId = HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                .Value.ToString();

            var preference = await _repo.GetUserHolidayPreferenceByIdAsync(id, userId);

            if (preference == null)
            {
                return NotFound(new ApiResponse(404));
            }

            preference.MinPrice = preferenceDTO.MinPrice;
            preference.MaxPrice = preferenceDTO.MaxPrice;
            preference.Websites = preferenceDTO.Websites;


            _repo.SaveChanges();

            return Ok(_mapper.Map<HolidayPreferences, HolidayPreferencesDTO>(preference));
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
