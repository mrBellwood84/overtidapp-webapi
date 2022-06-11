using Application.PublicDataService;
using Domain.Agreements.CollectiveAgreement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers.PublicData
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class CollectiveAgreementController : ControllerBase
    {
        private readonly IPublicDataService _data;

        public CollectiveAgreementController(IPublicDataService data)
        {
            _data = data;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<CollectiveAgreementEntity>>> GetAllCollectiveAgreements()
        {
            try
            {
                var result = await _data.CollectiveAgreementData.GetAll();

                return Ok(result);

            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
