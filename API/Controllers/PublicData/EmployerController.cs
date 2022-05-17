using Application.PublicDataService;
using Domain.Employment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers.PublicData
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IPublicDataService _publicData;
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey;

        public EmployerController(IPublicDataService publicData, IMemoryCache cache)
        {
            _publicData = publicData;
            _memoryCache = cache;
            _cacheKey = publicData.EmployerData.CacheKey;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Employer>>> GetAllEmployers()
        {
            try
            {
                var result = _memoryCache.Get<List<Employer>>(_cacheKey);

                if (result == null)
                {
                    result = await _publicData.EmployerData.GetAllEmployers();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Employer>> AddSingleEmployer(NewEmployerRequest request)
        {
            try
            {
                var result = await _publicData.EmployerData.AddNewEmployer(request);
                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("editrequest")]
        public async Task<ActionResult<List<EmployerEditRequest>>> GetAllEditRequests()
        {
            try
            {
                var result = await _publicData.EmployerData.GetAllEditRequests();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
