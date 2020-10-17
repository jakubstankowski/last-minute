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
        private readonly IGenericWebAPIClient _genericWebAPIClient;

        public HolidayOffersController(IHolidayOffersRepo repo, IMapper mapper, IHolidayPreferencesRepo preferencesRepo, IHolidayOffersService holidayOffersService, IGenericWebAPIClient genericWebAPIClient)
        {
            _repo = repo;
            _mapper = mapper;
            _preferencesRepo = preferencesRepo;
            _holidayOffersService = holidayOffersService;

            _genericWebAPIClient = genericWebAPIClient;
        }

        [HttpGet("webscrapper")]
        public ActionResult Webscrapper()
        {

            return Ok(200);
        }

        [HttpGet("refresh")]
        public async Task RefreshOffersAsync()
        {
           await _genericWebAPIClient.CollectTuiDataAsync();
        }

        // GET: api/offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayOffersDTO>>> GetOffers()
        {
            var offers = await _repo.GetHolidayOffersAsync();

            return Ok(_mapper.Map<IEnumerable<HolidayOffers>, IEnumerable<HolidayOffersDTO>>(offers));
        }

        // GET: api/offers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayOffersDTO>> GetOffersById(int id)
        {
            var offers = await _repo.GetHolidayOffersByIdAsync(id);
            if (offers == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<HolidayOffers, HolidayOffersDTO>(offers);
        }

        // GET: api/offers/by-preferences/{id}
        [Authorize]
        [HttpGet("by-user-preferences")]
        public async Task<ActionResult<IEnumerable<HolidayOffersDTO>>> GetOffersByUserPreferenceId()
        {

            var userId = HttpContext.User
                    .FindFirst(ClaimTypes.NameIdentifier)
                     .Value.ToString();

            var preferences = await _preferencesRepo.GetUserHolidayPreferences(userId);

            if (preferences == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var offers = await _repo.GetHolidayOffersAsync();

            var offersByUserHolidayPreferences = _holidayOffersService.GetHolidayOffersByUserHolidayPreference(offers, preferences);



            return Ok(_mapper
             .Map<IEnumerable<HolidayOffers>, IEnumerable<HolidayOffersDTO>>(offersByUserHolidayPreferences));


        }


        // POST: api/offers
        [HttpPost]
        public void Post(HolidayOffers offers)
        {
            _repo.CreateHolidayOffers(offers);
        }
    }
}
