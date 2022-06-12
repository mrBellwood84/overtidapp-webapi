using Application.PublicDataService;
using Domain.Employer;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        
        /// <summary>
        /// Get employers short info data list
        /// </summary>
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

        /// <summary>
        /// Get employers full info data list
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Add new employer with change suggestions from user
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EmployerEntity>> AddNewEmployer(EmployerCreateNewDto createNewDto)
        {
            try
            {
                var result = await _publicData.EmployerData.AddNewEmployer(createNewDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates an employer entity based on a change suggestion (frontend)
        /// </summary>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployerFromSuggestion(EmployerEditRequestDto editRequestDto)
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

        /// <summary>
        /// Delete an employer entity from
        /// </summary>
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployer(RequestByIdDto idDto)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role != "admin") return Forbid();

            return BadRequest("DEV :: Changes to employment contract is required before this option is available!!!");

            /*
            try
            {
                await _publicData.EmployerData.DeleteEmployer(idDto.Id);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            } 
            */
        }

        /// <summary>
        /// Get change suggestions for existing employer data from users
        /// </summary>
        [Authorize]
        [HttpPost("suggest")]
        public async Task<ActionResult<List<EmployerEditSuggestionEntity>>> GetNewEmployerEditSuggestions()
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

        /// <summary>
        /// Recive change suggestion for employer entity from user
        /// </summary>
        [HttpPost("suggest")]
        public async Task<IActionResult> AddEmployerChangeREquest(EmployerEditSuggestionDto editSuggestion)
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

        /// <summary>
        /// Delete a suggestion from database
        /// </summary>
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

        /// <summary>
        /// Delete range of suggestions from same user
        /// </summary>
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
