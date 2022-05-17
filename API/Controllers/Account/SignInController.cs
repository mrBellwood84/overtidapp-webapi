using Identity.Data;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Account
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;

        public SignInController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AppUserDto>> SignIn(SignInDto signInDto)
        {
            var user = await _userManager.FindByEmailAsync(signInDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, signInDto.Password, false);

            if (result.Succeeded)
            {
                var userDto = new AppUserDto
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    Role = user.Role,
                };

                return Ok(userDto);
            }


            return Unauthorized();
        }
    }
}
