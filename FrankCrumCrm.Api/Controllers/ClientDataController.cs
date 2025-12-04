using FrankCrumCrm.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrankCrumCrm.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ClientDataController : ControllerBase
    {
        private readonly CrmService _crmService;

        public ClientDataController(CrmService crmService)
        {
            _crmService = crmService;
        }

        /// <summary>
        /// Get client data by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientData(int id)
        {
            try
            {
                var clientData = await _crmService.GetClientDataAsync(id);
                return Ok(clientData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get division numbers for a client
        /// </summary>
        [HttpGet("{clientNumber}/division/numbers")]
        public async Task<IActionResult> GetDivisionNumbers(int clientNumber)
        {
            try
            {
                var divisionNumbers = await _crmService.GetDivisionNumbersAsync(clientNumber);
                return Ok(divisionNumbers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get payroll processing status clients
        /// </summary>
        [HttpPost("payrollprocessingstatusclients")]
        public async Task<IActionResult> GetPayrollProcessingStatusClients([FromBody] List<string> clientIds)
        {
            try
            {
                var clients = await _crmService.GetPayrollProcessingStatusClientsAsync(clientIds);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get PI Screen client information
        /// </summary>
        [HttpGet("pi-screen/{id}")]
        public async Task<IActionResult> GetPIScreenClientInformation(int id)
        {
            try
            {
                var info = await _crmService.GetPIScreenClientInformationAsync(id);
                return Ok(info);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
