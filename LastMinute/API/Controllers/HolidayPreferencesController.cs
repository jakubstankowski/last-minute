using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HolidayPreferences/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HolidayPreferences
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
