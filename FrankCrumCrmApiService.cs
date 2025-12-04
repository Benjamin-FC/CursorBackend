using System.Net.Http;

namespace FrankCrumCrmApiClient
{
    /// <summary>
    /// Service wrapper for FrankCrum CRM API client
    /// </summary>
    public class FrankCrumCrmApiService
    {
        private readonly FrankCrumCrmApiClient _client;

        public FrankCrumCrmApiService(HttpClient httpClient, string baseUrl)
        {
            _client = new FrankCrumCrmApiClient(httpClient, baseUrl);
        }

        public FrankCrumCrmApiService(string baseUrl, string? bearerToken = null)
        {
            var httpClient = new HttpClient();
            if (!string.IsNullOrEmpty(bearerToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
            }
            _client = new FrankCrumCrmApiClient(httpClient, baseUrl);
        }

        /// <summary>
        /// Sets the Bearer token for authentication
        /// </summary>
        public void SetBearerToken(string token)
        {
            _client.SetBearerToken(token);
        }

        // ClientData Service Methods
        public async Task<Models.ClientDataResponse> GetClientDataAsync(int id)
        {
            return await _client.GetClientDataAsync(id);
        }

        public async Task<List<string>> GetDivisionNumbersAsync(int clientNumber)
        {
            return await _client.GetDivisionNumbersAsync(clientNumber);
        }

        public async Task<Models.ClientDataListResponse> GetPayrollProcessingStatusClientsAsync(List<string> clientIds)
        {
            return await _client.GetPayrollProcessingStatusClientsAsync(clientIds);
        }

        public async Task<Models.PIScreenClientInformationResponse> GetPIScreenClientInformationAsync(int id)
        {
            return await _client.GetPIScreenClientInformationAsync(id);
        }

        public async Task<Models.PIScreenBillingInformationResponse> GetPIScreenBillingInformationAsync(int clientNumber)
        {
            return await _client.GetPIScreenBillingInformationAsync(clientNumber);
        }

        public async Task<List<Models.WCSurchargeResponse>> GetPIScreenWCSurchargeAsync(int clientNumber)
        {
            return await _client.GetPIScreenWCSurchargeAsync(clientNumber);
        }

        public async Task<Models.PIScreenPayrollInformationResponse> GetPIScreenPayrollInformationAsync(int id)
        {
            return await _client.GetPIScreenPayrollInformationAsync(id);
        }

        public async Task<bool> PostPIScreenNotesAsync(int id, string notes)
        {
            return await _client.PostPIScreenNotesAsync(id, notes);
        }

        public async Task<string> GetPayrollNotesAsync(int id)
        {
            return await _client.GetPayrollNotesAsync(id);
        }

        public async Task<bool> PostPayrollNotesAsync(int id, string notes)
        {
            return await _client.PostPayrollNotesAsync(id, notes);
        }

        public async Task<bool> PostBillingNotesAsync(int id, string notes)
        {
            return await _client.PostBillingNotesAsync(id, notes);
        }

        public async Task<string> GetBillingNotesAsync(int id)
        {
            return await _client.GetBillingNotesAsync(id);
        }

        public async Task<Models.EVerifyResponse> GetPIScreenEVerifyAsync(int id)
        {
            return await _client.GetPIScreenEVerifyAsync(id);
        }

        public async Task<Models.TerminatedClientsInformationResponse> GetTerminatedClientsAsync(List<string> clientIds)
        {
            return await _client.GetTerminatedClientsAsync(clientIds);
        }

        public async Task<List<Models.PIScreenClientContactResponse>> GetPIScreenContactsAsync(int id)
        {
            return await _client.GetPIScreenContactsAsync(id);
        }

        public async Task<List<Models.ContactTypeLookupResponse>> GetContactTypeLookupAsync()
        {
            return await _client.GetContactTypeLookupAsync();
        }

        public async Task<Models.PIScreenAdditionalContactResponse> GetPIScreenAdditionalContactInformationAsync(int contactId)
        {
            return await _client.GetPIScreenAdditionalContactInformationAsync(contactId);
        }

        public async Task<Models.OffsetsResponse> GetOffsetsAsync(int clientNumber, string divisionNumber)
        {
            return await _client.GetOffsetsAsync(clientNumber, divisionNumber);
        }

        public async Task<List<Models.ClientPayrollInformationResponse>> GetPayrollClientDataAsync(List<int> clientIds)
        {
            return await _client.GetPayrollClientDataAsync(clientIds);
        }

        public async Task<List<Models.ClientProcessingTeam>> GetClientProcessingTeamAsync(List<int> clientIds)
        {
            return await _client.GetClientProcessingTeamAsync(clientIds);
        }

        public async Task<Models.ProcessingTeamContacts> GetProcessingTeamContactsAsync(int clientNumber)
        {
            return await _client.GetProcessingTeamContactsAsync(clientNumber);
        }

        public async Task<bool> UpdateClientPinAsync(string coId, Models.UpdateClientPinRequest request)
        {
            return await _client.UpdateClientPinAsync(coId, request);
        }

        public async Task<bool> IsWOTCClientAsync(string coId)
        {
            return await _client.IsWOTCClientAsync(coId);
        }

        // OnboardingAutomation Service Methods
        public async Task<Models.EmployerOnbTemplatesProcessedModel> CreateOnboardingAutomationAsync(Models.AddEmployerOnbTemplatesProcessedRequest request)
        {
            return await _client.CreateOnboardingAutomationAsync(request);
        }

        public async Task<List<Models.EmployerOnbTemplatesProcessedModel>> GetAllOnboardingAutomationAsync()
        {
            return await _client.GetAllOnboardingAutomationAsync();
        }

        public async Task<Models.EmployerOnbTemplatesProcessedModel> GetOnboardingAutomationByIdAsync(int id)
        {
            return await _client.GetOnboardingAutomationByIdAsync(id);
        }

        public async Task<bool> UpdateOnboardingAutomationAsync(int id, Models.AddEmployerOnbTemplatesProcessedRequest request)
        {
            return await _client.UpdateOnboardingAutomationAsync(id, request);
        }

        public async Task<bool> DeleteOnboardingAutomationAsync(int id)
        {
            return await _client.DeleteOnboardingAutomationAsync(id);
        }

        // User Service Methods
        public async Task<List<Models.PayrollManagerResponse>> GetPayrollManagersAsync()
        {
            return await _client.GetPayrollManagersAsync();
        }
    }
}
