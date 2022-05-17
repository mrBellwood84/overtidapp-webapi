using Identity.Data;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers.Account
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class GetCurrentController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;

        public GetCurrentController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<AppUserDto>> GetCurrentUser()
        {
            // get username from token
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // get user from username provided by token
            var user = await _userManager.FindByNameAsync(username);

            // return bad request if no user found
            if (user == null) return BadRequest("Could not update user");

            // create app user dto for return

            var dto = new AppUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = user.Role,
            };

            return Ok(dto);
        }
    }
}
