using FrankCrumCrm.Application.DTOs;
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
        
        // Missing endpoints from Swagger
        Task<PIScreenBillingInformation> GetPIScreenBillingInformationAsync(int clientNumber);
        Task<List<WCSurcharge>> GetWCSurchargesAsync(int clientNumber);
        Task<PIScreenPayrollInformation> GetPIScreenPayrollInformationAsync(int id);
        Task<bool> UpdatePIScreenNotesAsync(int id, string notes);
        Task<string> GetPayrollNotesAsync(int id);
        Task<bool> UpdatePayrollNotesAsync(int id, string notes);
        Task<bool> UpdateBillingNotesAsync(int id, string notes);
        Task<string> GetBillingNotesAsync(int id);
        Task<EVerify> GetEVerifyAsync(int id);
        Task<TerminatedClientsInformation> GetTerminatedClientsAsync(List<string> clientIds);
        Task<List<PIScreenClientContact>> GetPIScreenContactsAsync(int id);
        Task<List<ContactTypeLookup>> GetContactTypeLookupAsync();
        Task<PIScreenAdditionalContact> GetPIScreenAdditionalContactAsync(int contactId);
        Task<Offsets> GetOffsetsAsync(int clientNumber, string divisionNumber);
        Task<List<ClientPayrollInformation>> GetClientPayrollInformationAsync(List<int> clientIds);
        Task<List<ClientProcessingTeam>> GetClientProcessingTeamAsync(List<int> clientIds);
        Task<ProcessingTeamContacts> GetProcessingTeamContactsAsync(int clientNumber);
        Task<bool> UpdateClientPinAsync(string coId, UpdateClientPinRequest request);
        Task<bool> IsWOTCClientAsync(string coId);
    }
}
