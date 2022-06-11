using Application.PublicDataService;
using Domain.Employer;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace API.Controllers.PublicData
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IPublicDataService _publicData;

        public EmployerController(IPublicDataService publicData)
        {
            _publicData = publicData;
        }
        

        [HttpGet]
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

        [HttpGet("full")]
        public async Task<ActionResult<List<EmployerEntity>>> GetAllEmployerFullInfo()
        {
            try
            {
                var result = await _publicData.EmployerData.GetEmployerFullDataList();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployerEntity>> AddNewEmployer(EmployerCreateNewDto createNewDto)
        {
            try
            {
                var res = await _publicData.EmployerData.AddNewEmployer(createNewDto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> AddEmployerEditSuggestion(EmployerEditRequestDto editRequestDto)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "admin") return Forbid();
            

            try
            {
                await _publicData.EmployerData.UpdateEmployer(editRequestDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployer(RequestByIdDto idDto)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "admin") return Forbid();

            try
            {
                await _publicData.EmployerData.DeleteEmployer(idDto.Id);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost("suggest")]
        public async Task<ActionResult<List<EmployerEditSuggestionEntity>>> GetNewEmployerEditSuggestion()
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "admin") return Forbid();

            try
            {
               var res = await _publicData.EmployerData.GetEmployerEditSuggestionList();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            
        }

        [HttpPost("suggest")]
        public async Task<IActionResult> AddEmployerEditSuggestion(EmployerEditSuggestionDto editSuggestion)
        {
            try
            {
                await _publicData.EmployerData.AddEmployerEditSuggestion(editSuggestion);

                return StatusCode(201, "Suggestion added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("suggest")]
        public async Task<IActionResult> DeleteSuggestionById(RequestByIdDto idDto)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "admin") return Forbid();

            try
            {
                await _publicData.EmployerData.DeleteSuggestionById(idDto.Id);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("suggest/deleteallfromuser")]
        public async Task<IActionResult> DeleteAllSuggestionsFromUser(RequestByUserNameDto userNameDto)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "admin") return Forbid();

            try
            {
                await _publicData.EmployerData.DeleteSuggestionByUserName(userNameDto.UserName);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
