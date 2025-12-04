using FrankCrumCrm.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrankCrumCrm.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Users")]
    [Authorize]
    public class PayrollManagerController : ControllerBase
    {
        private readonly CrmService _crmService;

        public PayrollManagerController(CrmService crmService)
        {
            _crmService = crmService;
        }

        /// <summary>
        /// Get all payroll managers
        /// </summary>
        [HttpGet("PayrollManagers")]
        public async Task<IActionResult> GetPayrollManagers()
        {
            try
            {
                var managers = await _crmService.GetPayrollManagersAsync();
                return Ok(managers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
