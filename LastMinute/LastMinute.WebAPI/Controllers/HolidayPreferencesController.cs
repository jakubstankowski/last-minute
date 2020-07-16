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

        // GET: api/preferences/5
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

        // POST: api/preferences
        [HttpPost]
        public ActionResult Post(HolidayPreferences holidayPreferences)
        {

            _repository.CreateHolidayPreference(holidayPreferences);
            _repository.SaveChanges();
            
            return Ok(holidayPreferences);

        }

        // PUT: api/preferences/5
        [HttpPut("{id}")]
        public ActionResult<HolidayPreferences> Put(int id, HolidayPreferences holidayPreferences)
        {
            var holidayPreference = _repository.GetHolidayPreferenceById(id);

            if (holidayPreference == null)
            {
                return NotFound();
            }


            _repository.UpdateHolidayPreference(holidayPreference);

            return holidayPreference;
        }

        // DELETE: api/preferences/5
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
