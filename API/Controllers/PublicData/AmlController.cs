using Application.PublicDataService;
using Domain.Agreements.Aml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers.PublicData
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class AmlController : ControllerBase
    {
        private readonly IPublicDataService _data;

        public AmlController(IPublicDataService publicData)
        {
            _data = publicData;
        }

        [HttpGet]
        public async Task<ActionResult<AmlEntity>> GetAmlEntity()
        {
            try
            {
                var result = await _data.AmlData.GetAmlEntity();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
