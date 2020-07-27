using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastMinute.WebAPI.App.User.Models;
using LastMinute.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LastMinute.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUser applicationUser)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = _mapper.Map<User>(userForRegisterDto);

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

            return CreatedAtRoute("GetUser", new
            {
                controller = "Users",
                id = createdUser.Id
            }, userToReturn);
        }

    }
}
