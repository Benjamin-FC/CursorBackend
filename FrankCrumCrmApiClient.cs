using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using FrankCrumCrmApiClient.Models;
using Newtonsoft.Json;

namespace FrankCrumCrmApiClient
{
    public class FrankCrumCrmApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public FrankCrumCrmApiClient(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = baseUrl?.TrimEnd('/') ?? throw new ArgumentNullException(nameof(baseUrl));
        }

        public void SetBearerToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
        }

        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content) 
                ?? throw new InvalidOperationException($"Failed to deserialize response from {endpoint}");
        }

        private async Task<T> PostAsync<T>(string endpoint, object? body = null)
        {
            var jsonContent = body != null 
                ? JsonConvert.SerializeObject(body)
                : null;
            
            var content = jsonContent != null
                ? new StringContent(jsonContent, Encoding.UTF8, "application/json")
                : null;

            var response = await _httpClient.PostAsync($"{_baseUrl}{endpoint}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent) 
                ?? throw new InvalidOperationException($"Failed to deserialize response from {endpoint}");
        }

        private async Task<T> PutAsync<T>(string endpoint, object? body = null)
        {
            var jsonContent = body != null 
                ? JsonConvert.SerializeObject(body)
                : null;
            
            var content = jsonContent != null
                ? new StringContent(jsonContent, Encoding.UTF8, "application/json")
                : null;

            var response = await _httpClient.PutAsync($"{_baseUrl}{endpoint}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent) 
                ?? throw new InvalidOperationException($"Failed to deserialize response from {endpoint}");
        }

        private async Task<T> DeleteAsync<T>(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}{endpoint}");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent) 
                ?? throw new InvalidOperationException($"Failed to deserialize response from {endpoint}");
        }

        // ClientData endpoints
        public async Task<ClientDataResponse> GetClientDataAsync(int id)
        {
            return await GetAsync<ClientDataResponse>($"/api/v1/ClientData/{id}");
        }

        public async Task<List<string>> GetDivisionNumbersAsync(int clientNumber)
        {
            return await GetAsync<List<string>>($"/api/v1/ClientData/{clientNumber}/division/numbers");
        }

        public async Task<ClientDataListResponse> GetPayrollProcessingStatusClientsAsync(List<string> clientIds)
        {
            return await PostAsync<ClientDataListResponse>("/api/v1/ClientData/payrollprocessingstatusclients", clientIds);
        }

        public async Task<PIScreenClientInformationResponse> GetPIScreenClientInformationAsync(int id)
        {
            return await GetAsync<PIScreenClientInformationResponse>($"/api/v1/ClientData/pi-screen/{id}");
        }

        public async Task<PIScreenBillingInformationResponse> GetPIScreenBillingInformationAsync(int clientNumber)
        {
            return await GetAsync<PIScreenBillingInformationResponse>($"/api/v1/ClientData/pi-screen/billing/{clientNumber}");
        }

        public async Task<List<WCSurchargeResponse>> GetPIScreenWCSurchargeAsync(int clientNumber)
        {
            return await GetAsync<List<WCSurchargeResponse>>($"/api/v1/ClientData/pi-screen/wcsurcharge/{clientNumber}");
        }

        public async Task<PIScreenPayrollInformationResponse> GetPIScreenPayrollInformationAsync(int id)
        {
            return await GetAsync<PIScreenPayrollInformationResponse>($"/api/v1/ClientData/pi-screen/payroll/{id}");
        }

        public async Task<bool> PostPIScreenNotesAsync(int id, string notes)
        {
            return await PostAsync<bool>($"/api/v1/ClientData/pi-screen/notes/{id}", notes);
        }

        public async Task<string> GetPayrollNotesAsync(int id)
        {
            return await GetAsync<string>($"/api/v1/ClientData/payroll/notes/{id}");
        }

        public async Task<bool> PostPayrollNotesAsync(int id, string notes)
        {
            return await PostAsync<bool>($"/api/v1/ClientData/payroll/notes/{id}", notes);
        }

        public async Task<bool> PostBillingNotesAsync(int id, string notes)
        {
            return await PostAsync<bool>($"/api/v1/ClientData/billing/notes/{id}", notes);
        }

        public async Task<string> GetBillingNotesAsync(int id)
        {
            return await GetAsync<string>($"/api/v1/ClientData/billing/notes/{id}");
        }

        public async Task<EVerifyResponse> GetPIScreenEVerifyAsync(int id)
        {
            return await GetAsync<EVerifyResponse>($"/api/v1/ClientData/pi-screen/everify/{id}");
        }

        public async Task<TerminatedClientsInformationResponse> GetTerminatedClientsAsync(List<string> clientIds)
        {
            return await PostAsync<TerminatedClientsInformationResponse>("/api/v1/ClientData/terminatedclients", clientIds);
        }

        public async Task<List<PIScreenClientContactResponse>> GetPIScreenContactsAsync(int id)
        {
            return await GetAsync<List<PIScreenClientContactResponse>>($"/api/v1/ClientData/pi-screen/contacts/{id}");
        }

        public async Task<List<ContactTypeLookupResponse>> GetContactTypeLookupAsync()
        {
            return await GetAsync<List<ContactTypeLookupResponse>>("/api/v1/ClientData/pi-screen/contacttypelookup");
        }

        public async Task<PIScreenAdditionalContactResponse> GetPIScreenAdditionalContactInformationAsync(int contactId)
        {
            return await GetAsync<PIScreenAdditionalContactResponse>($"/api/v1/ClientData/pi-screen/additional-contact-information/{contactId}");
        }

        public async Task<OffsetsResponse> GetOffsetsAsync(int clientNumber, string divisionNumber)
        {
            return await GetAsync<OffsetsResponse>($"/api/v1/ClientData/offsets/{clientNumber}/{divisionNumber}");
        }

        public async Task<List<ClientPayrollInformationResponse>> GetPayrollClientDataAsync(List<int> clientIds)
        {
            return await PostAsync<List<ClientPayrollInformationResponse>>("/api/v1/ClientData/payroll/clientdata", clientIds);
        }

        public async Task<List<ClientProcessingTeam>> GetClientProcessingTeamAsync(List<int> clientIds)
        {
            return await PostAsync<List<ClientProcessingTeam>>("/api/v1/ClientData/ClientProcessingTeam", clientIds);
        }

        public async Task<ProcessingTeamContacts> GetProcessingTeamContactsAsync(int clientNumber)
        {
            return await GetAsync<ProcessingTeamContacts>($"/api/v1/ClientData/{clientNumber}/ProcessingTeamContacts");
        }

        public async Task<bool> UpdateClientPinAsync(string coId, UpdateClientPinRequest request)
        {
            return await PostAsync<bool>($"/api/v1/ClientData/ClientPin/{coId}", request);
        }

        public async Task<bool> IsWOTCClientAsync(string coId)
        {
            return await GetAsync<bool>($"/api/v1/ClientData/isWOTCClient/{coId}");
        }

        // OnboardingAutomation endpoints
        public async Task<EmployerOnbTemplatesProcessedModel> CreateOnboardingAutomationAsync(AddEmployerOnbTemplatesProcessedRequest request)
        {
            return await PostAsync<EmployerOnbTemplatesProcessedModel>("/api/v1/OnboardingAutomation", request);
        }

        public async Task<List<EmployerOnbTemplatesProcessedModel>> GetAllOnboardingAutomationAsync()
        {
            return await GetAsync<List<EmployerOnbTemplatesProcessedModel>>("/api/v1/OnboardingAutomation");
        }

        public async Task<EmployerOnbTemplatesProcessedModel> GetOnboardingAutomationByIdAsync(int id)
        {
            return await GetAsync<EmployerOnbTemplatesProcessedModel>($"/api/v1/OnboardingAutomation/{id}");
        }

        public async Task<bool> UpdateOnboardingAutomationAsync(int id, AddEmployerOnbTemplatesProcessedRequest request)
        {
            return await PutAsync<bool>($"/api/v1/OnboardingAutomation/{id}", request);
        }

        public async Task<bool> DeleteOnboardingAutomationAsync(int id)
        {
            return await DeleteAsync<bool>($"/api/v1/OnboardingAutomation/{id}");
        }

        // User endpoints
        public async Task<List<PayrollManagerResponse>> GetPayrollManagersAsync()
        {
            return await GetAsync<List<PayrollManagerResponse>>("/api/v1/Users/PayrollManagers");
        }
    }
}
