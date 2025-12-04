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

        // Missing endpoints from Swagger
        public async Task<PIScreenBillingInformation> GetPIScreenBillingInformationAsync(int clientNumber)
        {
            return await _apiClient.GetPIScreenBillingInformationAsync(clientNumber);
        }

        public async Task<List<WCSurcharge>> GetWCSurchargesAsync(int clientNumber)
        {
            return await _apiClient.GetWCSurchargesAsync(clientNumber);
        }

        public async Task<PIScreenPayrollInformation> GetPIScreenPayrollInformationAsync(int id)
        {
            return await _apiClient.GetPIScreenPayrollInformationAsync(id);
        }

        public async Task<bool> UpdatePIScreenNotesAsync(int id, string notes)
        {
            return await _apiClient.UpdatePIScreenNotesAsync(id, notes);
        }

        public async Task<string> GetPayrollNotesAsync(int id)
        {
            return await _apiClient.GetPayrollNotesAsync(id);
        }

        public async Task<bool> UpdatePayrollNotesAsync(int id, string notes)
        {
            return await _apiClient.UpdatePayrollNotesAsync(id, notes);
        }

        public async Task<bool> UpdateBillingNotesAsync(int id, string notes)
        {
            return await _apiClient.UpdateBillingNotesAsync(id, notes);
        }

        public async Task<string> GetBillingNotesAsync(int id)
        {
            return await _apiClient.GetBillingNotesAsync(id);
        }

        public async Task<EVerify> GetEVerifyAsync(int id)
        {
            return await _apiClient.GetEVerifyAsync(id);
        }

        public async Task<TerminatedClientsInformation> GetTerminatedClientsAsync(List<string> clientIds)
        {
            return await _apiClient.GetTerminatedClientsAsync(clientIds);
        }

        public async Task<List<PIScreenClientContact>> GetPIScreenContactsAsync(int id)
        {
            return await _apiClient.GetPIScreenContactsAsync(id);
        }

        public async Task<List<ContactTypeLookup>> GetContactTypeLookupAsync()
        {
            return await _apiClient.GetContactTypeLookupAsync();
        }

        public async Task<PIScreenAdditionalContact> GetPIScreenAdditionalContactAsync(int contactId)
        {
            return await _apiClient.GetPIScreenAdditionalContactAsync(contactId);
        }

        public async Task<Offsets> GetOffsetsAsync(int clientNumber, string divisionNumber)
        {
            return await _apiClient.GetOffsetsAsync(clientNumber, divisionNumber);
        }

        public async Task<List<ClientPayrollInformation>> GetClientPayrollInformationAsync(List<int> clientIds)
        {
            return await _apiClient.GetClientPayrollInformationAsync(clientIds);
        }

        public async Task<List<ClientProcessingTeam>> GetClientProcessingTeamAsync(List<int> clientIds)
        {
            return await _apiClient.GetClientProcessingTeamAsync(clientIds);
        }

        public async Task<ProcessingTeamContacts> GetProcessingTeamContactsAsync(int clientNumber)
        {
            return await _apiClient.GetProcessingTeamContactsAsync(clientNumber);
        }

        public async Task<bool> UpdateClientPinAsync(string coId, UpdateClientPinRequest request)
        {
            return await _apiClient.UpdateClientPinAsync(coId, request);
        }

        public async Task<bool> IsWOTCClientAsync(string coId)
        {
            return await _apiClient.IsWOTCClientAsync(coId);
        }
    }
}
