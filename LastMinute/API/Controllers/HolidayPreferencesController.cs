using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class HolidayPreferencesController : ControllerBase
    {
        private IHolidayPreferencesRepo _repo;
        private readonly IMapper _mapper;

        public HolidayPreferencesController(IHolidayPreferencesRepo repo, IMapper mapper)
        {
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
            if(preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<HolidayPreferences, HolidayPreferencesToReturnDTO>(preferences);
        }

     

        // POST: api/HolidayPreferences
        [HttpPost]
        public ActionResult Post(HolidayPreferences holidayPreferences)
        {
            _repo.CreateHolidayPreference(holidayPreferences);
            _repo.SaveChanges();
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
