﻿using System.Collections.Generic;
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
        private readonly IItakaWebScrapper _itakaWebScrapper;

        public HolidayOffersController(IHolidayOffersRepo repo, IMapper mapper, IItakaWebScrapper itakaWebScrapper)
        {
            _repo = repo;
            _mapper = mapper;
            _itakaWebScrapper = itakaWebScrapper;
        }


        [HttpGet("webscrapper")]
        public ActionResult TestCollector()
        {
             _itakaWebScrapper.GetHtmlElements();
            return Ok(200);
        }

        // GET: api/HolidayOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayOffers>>> GetOffers()
        {
           
           var offers =  await _repo.GetHolidayOffersAsync();

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
