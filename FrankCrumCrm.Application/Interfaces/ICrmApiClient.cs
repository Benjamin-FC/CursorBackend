using FrankCrumCrm.Domain.Entities;

namespace FrankCrumCrm.Application.Interfaces
{
    public interface ICrmApiClient
    {
        Task<ClientData> GetClientDataAsync(int id);
        Task<List<string>> GetDivisionNumbersAsync(int clientNumber);
        Task<List<ClientData>> GetPayrollProcessingStatusClientsAsync(List<string> clientIds);
        Task<PIScreenClientInformation> GetPIScreenClientInformationAsync(int id);
        Task<List<PayrollManager>> GetPayrollManagersAsync();
        Task<EmployerOnbTemplatesProcessed> CreateOnboardingAutomationAsync(CreateOnboardingRequest request);
        Task<List<EmployerOnbTemplatesProcessed>> GetAllOnboardingAutomationAsync();
        Task<EmployerOnbTemplatesProcessed> GetOnboardingAutomationByIdAsync(int id);
        Task<bool> UpdateOnboardingAutomationAsync(int id, CreateOnboardingRequest request);
        Task<bool> DeleteOnboardingAutomationAsync(int id);
    }
}
