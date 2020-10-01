using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebScrapper;

namespace API.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class HolidayOffersController : ControllerBase
    {
        private readonly IHolidayOffersRepo _repo;
        private readonly IMapper _mapper;
        private readonly IHolidayPreferencesRepo _preferencesRepo;
        private readonly IHolidayOffersService _holidayOffersService;
        private readonly IGenericWebscrapper _genericWebscrapper;
        public HolidayOffersController(IHolidayOffersRepo repo, IMapper mapper, IHolidayPreferencesRepo preferencesRepo, IHolidayOffersService holidayOffersService, IGenericWebscrapper genericWebscrapper)
        {
            _repo = repo;
            _mapper = mapper;
            _preferencesRepo = preferencesRepo;
            _holidayOffersService = holidayOffersService;
            _genericWebscrapper = genericWebscrapper;
        }

        [HttpGet("webscrapper")]
        public ActionResult Webscrapper()
        {
            _genericWebscrapper.CollectItakaWebscrapperData();
            _genericWebscrapper.CollectTuiWebscrapperData();
            return Ok(200);
        }

        // GET: api/offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayOffersToReturnDTO>>> GetOffers()
        {

            var offers = await _repo.GetHolidayOffersAsync();

           
            return Ok(_mapper.Map<IEnumerable<HolidayOffers>, IEnumerable<HolidayOffersToReturnDTO>>(offers));
        }

        // GET: api/offers/{id}
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

        // GET: api/offers/by-preferences/{id}
        [Authorize]
        [HttpGet("by-user-preferences/{id}")]
        public async Task<ActionResult<IEnumerable<HolidayOffersToReturnDTO>>> GetOffersByUserPreferencesId(int id)
        {

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var preferences = await _preferencesRepo.GetUserHolidayPreferenceByIdAsync(id, userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var offers = await _repo.GetHolidayOffersAsync();

            var offersByUserHolidayPreferences = _holidayOffersService.GetHolidayOffersByUserHolidayPreferences(offers, preferences);

          

            return Ok(_mapper
             .Map<IEnumerable<HolidayOffers>, IEnumerable<HolidayOffersToReturnDTO>>(offersByUserHolidayPreferences));


        }


        // POST: api/offers
        [HttpPost]
        public void Post(HolidayOffers offers)
        {
            _repo.CreateHolidayOffers(offers);
        }

        // PUT: api/offers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/offers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
