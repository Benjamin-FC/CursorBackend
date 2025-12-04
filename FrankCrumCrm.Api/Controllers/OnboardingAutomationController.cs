using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrankCrumCrm.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OnboardingAutomationController : ControllerBase
    {
        private readonly CrmService _crmService;

        public OnboardingAutomationController(CrmService crmService)
        {
            _crmService = crmService;
        }

        /// <summary>
        /// Create a new onboarding automation
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOnboardingAutomation([FromBody] CreateOnboardingRequest request)
        {
            try
            {
                var result = await _crmService.CreateOnboardingAutomationAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get all onboarding automations
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllOnboardingAutomations()
        {
            try
            {
                var results = await _crmService.GetAllOnboardingAutomationAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get onboarding automation by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOnboardingAutomationById(int id)
        {
            try
            {
                var result = await _crmService.GetOnboardingAutomationByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Update an onboarding automation
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOnboardingAutomation(int id, [FromBody] CreateOnboardingRequest request)
        {
            try
            {
                var result = await _crmService.UpdateOnboardingAutomationAsync(id, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Delete an onboarding automation
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnboardingAutomation(int id)
        {
            try
            {
                var result = await _crmService.DeleteOnboardingAutomationAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
