using System.Collections.Generic;
using System.Threading.Tasks;
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

        public HolidayPreferencesController(IHolidayPreferencesRepo repo)
        {
            _repo = repo;
        }


        // GET: api/HolidayPreferences
        [HttpGet]
        public async Task<IReadOnlyList<HolidayPreferences>> Get()
        {
            return await _repo.GetHolidayPreferencesAsync();
        }



        /*  // GET: api/HolidayPreferences/5
          [HttpGet("{id}", Name = "Get")]
          public async Task<HolidayPreferences>
          {
              return await _repo.Get
          }*/

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
