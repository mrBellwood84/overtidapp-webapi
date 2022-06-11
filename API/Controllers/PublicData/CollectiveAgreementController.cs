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
        private readonly IMemoryCache _cache;
        private readonly string _cacheKey;

        public CollectiveAgreementController(IPublicDataService data, IMemoryCache cache)
        {
            _data       = data;
            _cache      = cache;
            _cacheKey   = data.CollectiveAgreementData.CacheKey;
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
