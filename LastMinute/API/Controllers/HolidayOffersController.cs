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
    [Route("api/offers")]
    [ApiController]
    public class HolidayOffersController : ControllerBase
    {
        private readonly IHolidayOffersRepo _repo;
        private readonly IMapper _mapper;
        private readonly IItakaWebscrapper _itakaWebScrapper;
        private readonly ITuiWebscrapper _tuiWebscrapper;

        public HolidayOffersController(IHolidayOffersRepo repo, IMapper mapper, IItakaWebscrapper itakaWebScrapper, ITuiWebscrapper tuiWebscrapper)
        {
            _repo = repo;
            _mapper = mapper;
            _itakaWebScrapper = itakaWebScrapper;
            _tuiWebscrapper = tuiWebscrapper;
        }


        [HttpGet("webscrapper")]
        public ActionResult Webscrapper()
        {
            _tuiWebscrapper.CollectWebscrapperData();
           //_itakaWebScrapper.CollectWebscrapperData();
            return Ok(200);
        }

        // GET: api/HolidayOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayOffers>>> GetOffers()
        {

            var offers = await _repo.GetHolidayOffersAsync();

            return Ok(_mapper
                .Map<IEnumerable<HolidayOffers>, IEnumerable<HolidayOffersToReturnDTO>>(offers));
        }

        // GET: api/HolidayOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayOffersToReturnDTO>> GetOffersById(int id)
        {
            var offers = await _repo.GetHolidayOffersByIdAsync(id);
            if (offers == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<HolidayOffers, HolidayOffersToReturnDTO>(offers);
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
