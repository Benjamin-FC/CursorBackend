using System.Net.Http.Headers;
using System.Text;
using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Application.Interfaces;
using FrankCrumCrm.Domain.Entities;
using Newtonsoft.Json;

namespace FrankCrumCrm.Infrastructure.Clients
{
    public class CrmApiClient : ICrmApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CrmApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = httpClient.BaseAddress?.ToString().TrimEnd('/') 
                ?? throw new InvalidOperationException("HttpClient BaseAddress must be set");
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

        public async Task<ClientData> GetClientDataAsync(int id)
        {
            return await GetAsync<ClientData>($"/api/v1/ClientData/{id}");
        }

        public async Task<List<string>> GetDivisionNumbersAsync(int clientNumber)
        {
            return await GetAsync<List<string>>($"/api/v1/ClientData/{clientNumber}/division/numbers");
        }

        public async Task<List<ClientData>> GetPayrollProcessingStatusClientsAsync(List<string> clientIds)
        {
            var response = await PostAsync<ClientDataListResponse>("/api/v1/ClientData/payrollprocessingstatusclients", clientIds);
            return response.Clients ?? new List<ClientData>();
        }

        public async Task<PIScreenClientInformation> GetPIScreenClientInformationAsync(int id)
        {
            return await GetAsync<PIScreenClientInformation>($"/api/v1/ClientData/pi-screen/{id}");
        }

        public async Task<List<PayrollManager>> GetPayrollManagersAsync()
        {
            return await GetAsync<List<PayrollManager>>("/api/v1/Users/PayrollManagers");
        }

        public async Task<EmployerOnbTemplatesProcessed> CreateOnboardingAutomationAsync(CreateOnboardingRequest request)
        {
            var requestBody = new
            {
                newOnboardingPIN = request.NewOnboardingPin,
                processedFlag = request.ProcessedFlag,
                ultiproCompanyID = request.UltiproCompanyId,
                worklioID = request.WorklioId,
                clientNumber = request.ClientNumber,
                legalEntityDivisionID = request.LegalEntityDivisionId
            };
            return await PostAsync<EmployerOnbTemplatesProcessed>("/api/v1/OnboardingAutomation", requestBody);
        }

        public async Task<List<EmployerOnbTemplatesProcessed>> GetAllOnboardingAutomationAsync()
        {
            return await GetAsync<List<EmployerOnbTemplatesProcessed>>("/api/v1/OnboardingAutomation");
        }

        public async Task<EmployerOnbTemplatesProcessed> GetOnboardingAutomationByIdAsync(int id)
        {
            return await GetAsync<EmployerOnbTemplatesProcessed>($"/api/v1/OnboardingAutomation/{id}");
        }

        public async Task<bool> UpdateOnboardingAutomationAsync(int id, CreateOnboardingRequest request)
        {
            var requestBody = new
            {
                newOnboardingPIN = request.NewOnboardingPin,
                processedFlag = request.ProcessedFlag,
                ultiproCompanyID = request.UltiproCompanyId,
                worklioID = request.WorklioId,
                clientNumber = request.ClientNumber,
                legalEntityDivisionID = request.LegalEntityDivisionId
            };
            return await PutAsync<bool>($"/api/v1/OnboardingAutomation/{id}", requestBody);
        }

        public async Task<bool> DeleteOnboardingAutomationAsync(int id)
        {
            return await DeleteAsync<bool>($"/api/v1/OnboardingAutomation/{id}");
        }

        private class ClientDataListResponse
        {
            [JsonProperty("clients")]
            public List<ClientData>? Clients { get; set; }
        }
    }
}
