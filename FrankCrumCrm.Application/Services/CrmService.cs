using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Application.Interfaces;
using FrankCrumCrm.Domain.Entities;

namespace FrankCrumCrm.Application.Services
{
    public class CrmService
    {
        private readonly ICrmApiClient _apiClient;

        public CrmService(ICrmApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ClientData> GetClientDataAsync(int id)
        {
            return await _apiClient.GetClientDataAsync(id);
        }

        public async Task<List<string>> GetDivisionNumbersAsync(int clientNumber)
        {
            return await _apiClient.GetDivisionNumbersAsync(clientNumber);
        }

        public async Task<List<ClientData>> GetPayrollProcessingStatusClientsAsync(List<string> clientIds)
        {
            return await _apiClient.GetPayrollProcessingStatusClientsAsync(clientIds);
        }

        public async Task<PIScreenClientInformation> GetPIScreenClientInformationAsync(int id)
        {
            return await _apiClient.GetPIScreenClientInformationAsync(id);
        }

        public async Task<List<PayrollManager>> GetPayrollManagersAsync()
        {
            return await _apiClient.GetPayrollManagersAsync();
        }

        public async Task<EmployerOnbTemplatesProcessed> CreateOnboardingAutomationAsync(CreateOnboardingRequest request)
        {
            return await _apiClient.CreateOnboardingAutomationAsync(request);
        }

        public async Task<List<EmployerOnbTemplatesProcessed>> GetAllOnboardingAutomationAsync()
        {
            return await _apiClient.GetAllOnboardingAutomationAsync();
        }

        public async Task<EmployerOnbTemplatesProcessed> GetOnboardingAutomationByIdAsync(int id)
        {
            return await _apiClient.GetOnboardingAutomationByIdAsync(id);
        }

        public async Task<bool> UpdateOnboardingAutomationAsync(int id, CreateOnboardingRequest request)
        {
            return await _apiClient.UpdateOnboardingAutomationAsync(id, request);
        }

        public async Task<bool> DeleteOnboardingAutomationAsync(int id)
        {
            return await _apiClient.DeleteOnboardingAutomationAsync(id);
        }
    }
}
