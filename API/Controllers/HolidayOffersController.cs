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

namespace API.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class HolidayOffersController : ControllerBase
    {
        private readonly IHolidayOffersRepo _repo;
        private readonly IMapper _mapper;
        private readonly IHolidayOffersService _holidayOffersService;

        public HolidayOffersController(IHolidayOffersRepo repo, IMapper mapper, IHolidayPreferencesRepo preferencesRepo, IHolidayOffersService holidayOffersService)
        {
            _repo = repo;
            _mapper = mapper;
            _holidayOffersService = holidayOffersService;
        }


        // GET: api/offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayOffersDTO>>> GetOffers()
        {
            await _holidayOffersService.RefreshAllOffers();
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



    }
}
