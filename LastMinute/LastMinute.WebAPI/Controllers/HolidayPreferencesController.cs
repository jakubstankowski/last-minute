using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.Data;
using LastMinute.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastMinute.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class HolidayPreferencesController : ControllerBase
    {

        private readonly IHolidayPreferencesRepo _repository;

        public HolidayPreferencesController(IHolidayPreferencesRepo repository)
        {                                   
            _repository = repository;
        }

      

        // GET: api/preferences
        [HttpGet]
        public IEnumerable<HolidayPreferences> GetAllPreferences()
        {
            return _repository.GetAllHolidayPreferences().ToList();
        }

        // GET: api/HolidayPreferences/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<HolidayPreferences> Get(int id)
        {
            var holidayPreference = _repository.GetHolidayPreferenceById(id);

            if (holidayPreference == null)
            {
                return NotFound();
            }

            return holidayPreference;
        }

        // POST: api/HolidayPreferences
        [HttpPost]
        public ActionResult Post(HolidayPreferences holidayPreferences)
        {

            _repository.CreateHolidayPreference(holidayPreferences);
            _repository.SaveChanges();
            
            return Ok(holidayPreferences);

        }

        // PUT: api/HolidayPreferences/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<HolidayPreferences> Delete(int id)
        {
            var holidayPreference = _repository.GetHolidayPreferenceById(id);

            if (holidayPreference == null)
            {
                return NotFound();
            }

            _repository.DeleteHolidayPreference(holidayPreference);
            _repository.SaveChanges();

            return holidayPreference;
        }
    }
}
