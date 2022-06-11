using Identity.Data;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Account
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;

        public SignUpController (UserManager<AppUser> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AppUserDto>> SignUp(SignUpDto signUpDto)
        {
            // return bad request if email exist
            var emailExist = await _userManager.Users.AnyAsync(x => x.Email == signUpDto.Email);
            if (emailExist) return BadRequest("Email exist");

            var newUser = new AppUser
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                UserName = $"user-{Guid.NewGuid()}",
                Email = signUpDto.Email,
                Role = "user"
            };

            var result = await _userManager.CreateAsync(newUser, signUpDto.Password);

            if (result.Succeeded)
            {
                var userDto = new AppUserDto
                {
                    FirstName = newUser.FirstName,
                    LastName= newUser.LastName,
                    Email = newUser.Email,
                    Token = _tokenService.CreateToken(newUser),
                    Role = newUser.Role
                };

                return Created("New user created", userDto);
            }

            return StatusCode(500, "Could not create new user!");

        }
    }
}
