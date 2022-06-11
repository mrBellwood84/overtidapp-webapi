using Application.PublicDataService;
using Domain.Employer;
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

        public EmployerController(IPublicDataService publicData, IMemoryCache cache)
        {
            _publicData = publicData;
        }
        

        [HttpGet("short")]
        [AllowAnonymous]
        public async Task<ActionResult<List<EmployerShortDto>>> GetAllEmployers()
        {
            try
            {
                var result = await _publicData.EmployerData.GetEmployerShortInfo();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /*
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
        */
    }
}
