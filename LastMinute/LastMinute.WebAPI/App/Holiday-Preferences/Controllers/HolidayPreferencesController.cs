using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using LastMinute.Data;
using LastMinute.Models;
using LastMinute.WebAPI.App.Auth.Infrastructure;
using LastMinute.WebAPI.App.User.Models;
using LastMinute.WebAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastMinute.Controllers
{
    [Route("api/preferences")]
    [ApiController]
    public class HolidayPreferencesController : ControllerBase
    {

        private readonly IHolidayPreferencesRepo _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthContext _authContext;

        public HolidayPreferencesController(IHolidayPreferencesRepo repository, IMapper mapper, UserManager<ApplicationUser> userManager, AuthContext authContext)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _authContext = authContext;
        }



        // GET: api/preferences
        [HttpGet]
        public ActionResult<IEnumerable<HolidayPreferencesReadDto>> GetAllPreferences()
        {
            var holidayPreferences = _repository.GetAllHolidayPreferences();

            return Ok(_mapper.Map<IEnumerable<HolidayPreferencesReadDto>>(holidayPreferences));
        }

        // GET: api/preferences/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<HolidayPreferencesReadDto> GetPreferenceById(int id)
        {
            var holidayPreference = _repository.GetHolidayPreferenceById(id);

            if (holidayPreference == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<HolidayPreferencesReadDto>(holidayPreference));

        }

        // POST: api/preferences
        [HttpPost]
        public ActionResult<HolidayPreferencesReadDto> CreatePreference(HolidayPreferencesCreateDto holidayPreferencesDto)
        {

            var preferenceModel = _mapper.Map<HolidayPreferences>(holidayPreferencesDto);

            var user = _authContext.Users.FirstOrDefault(u => u.Id == preferenceModel.UserId);
            preferenceModel.User = user;

            _repository.CreateHolidayPreference(preferenceModel);
            _repository.SaveChanges();

            return Ok(_mapper.Map<HolidayPreferencesReadDto>(preferenceModel));
        }



        // PUT: api/preferences/5
        [HttpPut("{id}")]
        public ActionResult<HolidayPreferencesReadDto> UpdatePreference(int id, HolidayPreferencesUpdateDto holidayPreferencesUpdateDto)
        {
            var holidayPreference = _repository.GetHolidayPreferenceById(id);

            if (holidayPreference == null)
            {
                return NotFound();
            }


            _mapper.Map(holidayPreferencesUpdateDto, holidayPreference);

            _repository.UpdateHolidayPreference(holidayPreference);
            _repository.SaveChanges();

            return Ok(_mapper.Map<HolidayPreferencesReadDto>(holidayPreference));

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
