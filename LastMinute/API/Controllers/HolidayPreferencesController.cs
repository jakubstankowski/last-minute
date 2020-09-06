using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using API.Extenions;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class HolidayPreferencesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private IHolidayPreferencesRepo _repo;
        private readonly IMapper _mapper;

        public HolidayPreferencesController(IHolidayPreferencesRepo repo, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _repo = repo;
            _mapper = mapper;
        }


        // GET: api/HolidayPreferences
      
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<HolidayPreferencesToReturnDTO>>> GetPreferences()
        {
          var preferences = await _repo.GetHolidayPreferencesAsync();

            return Ok(_mapper
                .Map<IReadOnlyList<HolidayPreferences>, IReadOnlyList<HolidayPreferencesToReturnDTO>>(preferences));
        }



        // GET: api/preferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayPreferencesToReturnDTO>> GetPreferencesById(int id)
        {
            var preferences = await _repo.GetHolidayPreferenceByIdAsync(id);
            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<HolidayPreferences, HolidayPreferencesToReturnDTO>(preferences);
        }



        // POST: api/HolidayPreferences
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostAsync(HolidayPreferences holidayPreferences)
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            if (user == null)
            {
                return NotFound(new ApiResponse(404));
            }

            user.HolidayPreferences.Add(holidayPreferences);
            await _userManager.UpdateAsync(user);
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
