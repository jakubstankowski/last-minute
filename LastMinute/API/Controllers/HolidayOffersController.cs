using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class HolidayOffersController : ControllerBase
    {
        private readonly IHolidayOffersRepo _repo;

        public HolidayOffersController(IHolidayOffersRepo repo)
        {
            _repo = repo;
        }


        // GET: api/HolidayOffers
        [HttpGet]
        public async Task<IReadOnlyList<HolidayOffers>> Get()
        {
            return await _repo.GetHolidayOffersAsync();
        }

        // GET: api/HolidayOffers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HolidayOffers
        [HttpPost]
        public void Post(HolidayOffers offers)
        {
            _repo.CreateHolidayOffers(offers);
        }

        // PUT: api/HolidayOffers/5
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
