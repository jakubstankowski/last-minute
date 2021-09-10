using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/preferences-websites")]
    [ApiController]
    public class HolidayPreferencesWebsitesController : ControllerBase
    {
        private readonly IHolidayPreferencesWebsites _repo;
        private readonly IMapper _mapper;

        public HolidayPreferencesWebsitesController(IHolidayPreferencesWebsites repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/<HolidayPreferencesWebsitesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayPreferencesWebsitesDTO>>> Get()
        {
            var websites = await _repo.GetHolidayPreferencesWebsitesAsync();

            return Ok(_mapper.Map<IEnumerable<HolidayPreferencesWebsites>, IEnumerable<HolidayPreferencesWebsitesDTO>>(websites));
        }

        // GET api/<HolidayPreferencesWebsitesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HolidayPreferencesWebsitesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HolidayPreferencesWebsitesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HolidayPreferencesWebsitesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var holidayPreferencesWebsite = await _repo.GetHolidayPreferencesWebsitesByIdAsync(id);

            if (holidayPreferencesWebsite == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _repo.DeleteHolidayPreferenceWebsite(holidayPreferencesWebsite);
            _repo.SaveChanges();

            return Ok(200);

        }
    }
}
