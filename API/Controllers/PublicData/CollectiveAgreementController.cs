using Application.PublicDataService;
using Domain.Agreements.CollectiveAgreement;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult<CollectiveAgreementEntity>> GetSingleById(RequestByIdDto id)
        {
            try
            {
                var result = await _data.CollectiveAgreementData.GetSingleById(id.Id);

                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
