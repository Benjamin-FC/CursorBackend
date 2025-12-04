using FrankCrumCrmApiClient;
using FrankCrumCrmApiClient.Models;

namespace Example
{
    public class ExampleUsage
    {
        public static async Task Main()
        {
            // Initialize the service with base URL and optional bearer token
            var baseUrl = "https://api.example.com";
            var bearerToken = "your-bearer-token-here";
            
            var service = new FrankCrumCrmApiService(baseUrl, bearerToken);

            // Or use with HttpClient for dependency injection
            // var httpClient = new HttpClient();
            // var service = new FrankCrumCrmApiService(httpClient, baseUrl);
            // service.SetBearerToken(bearerToken);

            // Example: Get client data
            try
            {
                var clientData = await service.GetClientDataAsync(123);
                Console.WriteLine($"Client: {clientData.ClientLegalName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Example: Get division numbers
            var divisionNumbers = await service.GetDivisionNumbersAsync(123);
            Console.WriteLine($"Division Numbers: {string.Join(", ", divisionNumbers)}");

            // Example: Get PI Screen client information
            var piScreenInfo = await service.GetPIScreenClientInformationAsync(123);
            Console.WriteLine($"Client Name: {piScreenInfo.ClientName}");

            // Example: Get payroll managers
            var payrollManagers = await service.GetPayrollManagersAsync();
            foreach (var manager in payrollManagers)
            {
                Console.WriteLine($"Manager: {manager.Name}");
            }

            // Example: Create onboarding automation
            var onboardingRequest = new AddEmployerOnbTemplatesProcessedRequest
            {
                ClientNumber = "12345",
                ProcessedFlag = false,
                LegalEntityDivisionId = 1
            };
            var created = await service.CreateOnboardingAutomationAsync(onboardingRequest);
            Console.WriteLine($"Created onboarding automation with ID: {created.Id}");
        }
    }
}
