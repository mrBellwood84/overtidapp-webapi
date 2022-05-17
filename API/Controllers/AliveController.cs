using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AliveController : ControllerBase
    {

        [HttpGet]
        public IActionResult IsAlive()
        {
            return Ok("Alive");
        }
    }
}
