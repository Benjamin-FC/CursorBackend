# FrankCrum CRM API Client

A C# REST API client service for the FrankCrum.Crm.Api, generated from the OpenAPI/Swagger specification.

## Features

- Full type-safe C# models for all API schemas
- Service wrapper class for easy API access
- Bearer token authentication support
- All endpoints from the Swagger specification implemented

## Installation

1. Ensure you have .NET 8.0 SDK installed
2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
3. Build the project:
   ```bash
   dotnet build
   ```

## Usage

### Basic Usage

```csharp
using FrankCrumCrmApiClient;
using FrankCrumCrmApiClient.Models;

// Initialize the service
var baseUrl = "https://api.example.com";
var bearerToken = "your-bearer-token-here";
var service = new FrankCrumCrmApiService(baseUrl, bearerToken);

// Get client data
var clientData = await service.GetClientDataAsync(123);
Console.WriteLine($"Client: {clientData.ClientLegalName}");
```

### Using with Dependency Injection

```csharp
// In your Startup.cs or Program.cs
services.AddHttpClient<FrankCrumCrmApiService>(client =>
{
    client.BaseAddress = new Uri("https://api.example.com");
});

// In your service/controller
public class MyService
{
    private readonly FrankCrumCrmApiService _apiService;
    
    public MyService(HttpClient httpClient)
    {
        _apiService = new FrankCrumCrmApiService(
            httpClient, 
            "https://api.example.com"
        );
        _apiService.SetBearerToken("your-token");
    }
}
```

### Available Service Methods

#### ClientData Operations
- `GetClientDataAsync(int id)` - Get client data by ID
- `GetDivisionNumbersAsync(int clientNumber)` - Get division numbers for a client
- `GetPayrollProcessingStatusClientsAsync(List<string> clientIds)` - Get payroll processing status
- `GetPIScreenClientInformationAsync(int id)` - Get PI screen client information
- `GetPIScreenBillingInformationAsync(int clientNumber)` - Get billing information
- `GetPIScreenWCSurchargeAsync(int clientNumber)` - Get WC surcharges
- `GetPIScreenPayrollInformationAsync(int id)` - Get payroll information
- `GetPIScreenEVerifyAsync(int id)` - Get E-Verify information
- `GetPIScreenContactsAsync(int id)` - Get client contacts
- `GetContactTypeLookupAsync()` - Get contact type lookup
- `GetPIScreenAdditionalContactInformationAsync(int contactId)` - Get additional contact info
- `GetOffsetsAsync(int clientNumber, string divisionNumber)` - Get offsets
- `GetPayrollClientDataAsync(List<int> clientIds)` - Get payroll client data
- `GetClientProcessingTeamAsync(List<int> clientIds)` - Get processing team
- `GetProcessingTeamContactsAsync(int clientNumber)` - Get processing team contacts
- `UpdateClientPinAsync(string coId, UpdateClientPinRequest request)` - Update client PIN
- `IsWOTCClientAsync(string coId)` - Check if WOTC client
- `GetTerminatedClientsAsync(List<string> clientIds)` - Get terminated clients
- `GetPayrollNotesAsync(int id)` / `PostPayrollNotesAsync(int id, string notes)` - Payroll notes
- `GetBillingNotesAsync(int id)` / `PostBillingNotesAsync(int id, string notes)` - Billing notes
- `PostPIScreenNotesAsync(int id, string notes)` - Post PI screen notes

#### OnboardingAutomation Operations
- `CreateOnboardingAutomationAsync(AddEmployerOnbTemplatesProcessedRequest request)` - Create
- `GetAllOnboardingAutomationAsync()` - Get all
- `GetOnboardingAutomationByIdAsync(int id)` - Get by ID
- `UpdateOnboardingAutomationAsync(int id, AddEmployerOnbTemplatesProcessedRequest request)` - Update
- `DeleteOnboardingAutomationAsync(int id)` - Delete

#### User Operations
- `GetPayrollManagersAsync()` - Get all payroll managers

## Project Structure

```
├── Models/                          # All API model classes
│   ├── ClientDataResponse.cs
│   ├── PIScreenClientInformationResponse.cs
│   └── ... (other models)
├── FrankCrumCrmApiClient.cs        # Base API client
├── FrankCrumCrmApiService.cs       # Service wrapper
├── ExampleUsage.cs                  # Usage examples
└── FrankCrumCrmApiClient.csproj    # Project file
```

## Authentication

The API uses Bearer token authentication. Set your token when creating the service or use `SetBearerToken()` method:

```csharp
service.SetBearerToken("your-token-here");
```

## Error Handling

All methods will throw `HttpRequestException` if the HTTP request fails, or `InvalidOperationException` if response deserialization fails. Wrap calls in try-catch blocks:

```csharp
try
{
    var result = await service.GetClientDataAsync(123);
}
catch (HttpRequestException ex)
{
    // Handle HTTP errors
}
catch (Exception ex)
{
    // Handle other errors
}
```

## Dependencies

- .NET 8.0
- Newtonsoft.Json (13.0.3)
- System.Net.Http.Json (8.0.0)