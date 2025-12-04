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

        /// <summary>
        /// Get PI Screen billing information
        /// </summary>
        [HttpGet("pi-screen/billing/{clientNumber}")]
        public async Task<IActionResult> GetPIScreenBillingInformation(int clientNumber)
        {
            try
            {
                var info = await _crmService.GetPIScreenBillingInformationAsync(clientNumber);
                return Ok(info);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get WC surcharges for a client
        /// </summary>
        [HttpGet("pi-screen/wcsurcharge/{clientNumber}")]
        public async Task<IActionResult> GetWCSurcharges(int clientNumber)
        {
            try
            {
                var surcharges = await _crmService.GetWCSurchargesAsync(clientNumber);
                return Ok(surcharges);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get PI Screen payroll information
        /// </summary>
        [HttpGet("pi-screen/payroll/{id}")]
        public async Task<IActionResult> GetPIScreenPayrollInformation(int id)
        {
            try
            {
                var info = await _crmService.GetPIScreenPayrollInformationAsync(id);
                return Ok(info);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Update PI Screen notes
        /// </summary>
        [HttpPost("pi-screen/notes/{id}")]
        public async Task<IActionResult> UpdatePIScreenNotes(int id, [FromBody] string notes)
        {
            try
            {
                var result = await _crmService.UpdatePIScreenNotesAsync(id, notes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get payroll notes
        /// </summary>
        [HttpGet("payroll/notes/{id}")]
        public async Task<IActionResult> GetPayrollNotes(int id)
        {
            try
            {
                var notes = await _crmService.GetPayrollNotesAsync(id);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Update payroll notes
        /// </summary>
        [HttpPost("payroll/notes/{id}")]
        public async Task<IActionResult> UpdatePayrollNotes(int id, [FromBody] string notes)
        {
            try
            {
                var result = await _crmService.UpdatePayrollNotesAsync(id, notes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Update billing notes
        /// </summary>
        [HttpPost("billing/notes/{id}")]
        public async Task<IActionResult> UpdateBillingNotes(int id, [FromBody] string notes)
        {
            try
            {
                var result = await _crmService.UpdateBillingNotesAsync(id, notes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get billing notes
        /// </summary>
        [HttpGet("billing/notes/{id}")]
        public async Task<IActionResult> GetBillingNotes(int id)
        {
            try
            {
                var notes = await _crmService.GetBillingNotesAsync(id);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get E-Verify information
        /// </summary>
        [HttpGet("pi-screen/everify/{id}")]
        public async Task<IActionResult> GetEVerify(int id)
        {
            try
            {
                var eVerify = await _crmService.GetEVerifyAsync(id);
                return Ok(eVerify);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get terminated clients information
        /// </summary>
        [HttpPost("terminatedclients")]
        public async Task<IActionResult> GetTerminatedClients([FromBody] List<string> clientIds)
        {
            try
            {
                var result = await _crmService.GetTerminatedClientsAsync(clientIds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get PI Screen contacts
        /// </summary>
        [HttpGet("pi-screen/contacts/{id}")]
        public async Task<IActionResult> GetPIScreenContacts(int id)
        {
            try
            {
                var contacts = await _crmService.GetPIScreenContactsAsync(id);
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get contact type lookup
        /// </summary>
        [HttpGet("pi-screen/contacttypelookup")]
        public async Task<IActionResult> GetContactTypeLookup()
        {
            try
            {
                var lookup = await _crmService.GetContactTypeLookupAsync();
                return Ok(lookup);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get PI Screen additional contact information
        /// </summary>
        [HttpGet("pi-screen/additional-contact-information/{contactId}")]
        public async Task<IActionResult> GetPIScreenAdditionalContact(int contactId)
        {
            try
            {
                var contact = await _crmService.GetPIScreenAdditionalContactAsync(contactId);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get offsets for a client and division
        /// </summary>
        [HttpGet("offsets/{clientNumber}/{divisionNumber}")]
        public async Task<IActionResult> GetOffsets(int clientNumber, string divisionNumber)
        {
            try
            {
                var offsets = await _crmService.GetOffsetsAsync(clientNumber, divisionNumber);
                return Ok(offsets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get client payroll information
        /// </summary>
        [HttpPost("payroll/clientdata")]
        public async Task<IActionResult> GetClientPayrollInformation([FromBody] List<int> clientIds)
        {
            try
            {
                var info = await _crmService.GetClientPayrollInformationAsync(clientIds);
                return Ok(info);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get client processing team
        /// </summary>
        [HttpPost("ClientProcessingTeam")]
        public async Task<IActionResult> GetClientProcessingTeam([FromBody] List<int> clientIds)
        {
            try
            {
                var team = await _crmService.GetClientProcessingTeamAsync(clientIds);
                return Ok(team);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Get processing team contacts
        /// </summary>
        [HttpGet("{clientNumber}/ProcessingTeamContacts")]
        public async Task<IActionResult> GetProcessingTeamContacts(int clientNumber)
        {
            try
            {
                var contacts = await _crmService.GetProcessingTeamContactsAsync(clientNumber);
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Update client PIN
        /// </summary>
        [HttpPost("ClientPin/{coId}")]
        public async Task<IActionResult> UpdateClientPin(string coId, [FromBody] Application.DTOs.UpdateClientPinRequest request)
        {
            try
            {
                var result = await _crmService.UpdateClientPinAsync(coId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Check if client is WOTC client
        /// </summary>
        [HttpGet("isWOTCClient/{coId}")]
        public async Task<IActionResult> IsWOTCClient(string coId)
        {
            try
            {
                var result = await _crmService.IsWOTCClientAsync(coId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
