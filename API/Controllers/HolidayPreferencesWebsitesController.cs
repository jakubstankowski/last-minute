using System.Collections.Generic;
using System.Threading.Tasks;
using API.Errors;
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

        public HolidayPreferencesWebsitesController(IHolidayPreferencesWebsites repo)
        {
            _repo = repo;
        }
        // GET: api/<HolidayPreferencesWebsitesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
