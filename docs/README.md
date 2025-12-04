# FrankCrum CRM API

A clean architecture REST API for FrankCrum CRM operations, built with .NET 8.0 and organized in a layered architecture.

## Architecture

The solution follows Clean Architecture principles with four distinct layers:

### 🏗️ Layer Structure

```
FrankCrumCrm.sln
├── FrankCrumCrm.Api              # API Layer - Controllers, Swagger, Authentication
├── FrankCrumCrm.Application      # Application Layer - Services, DTOs, Interfaces
├── FrankCrumCrm.Domain           # Domain Layer - Entities, Domain Models
└── FrankCrumCrm.Infrastructure   # Infrastructure Layer - External API Clients, HTTP
```

#### **API Layer** (`FrankCrumCrm.Api`)
- REST API Controllers
- Swagger/OpenAPI configuration
- Bearer token authentication middleware
- Request/Response handling

#### **Application Layer** (`FrankCrumCrm.Application`)
- Business logic services
- DTOs (Data Transfer Objects)
- Application interfaces
- Use case orchestration

#### **Domain Layer** (`FrankCrumCrm.Domain`)
- Domain entities
- Domain models
- Core business entities

#### **Infrastructure Layer** (`FrankCrumCrm.Infrastructure`)
- External API client implementations
- HTTP client configuration
- External service integrations

## Features

- ✅ Clean Architecture with separation of concerns
- ✅ Swagger/OpenAPI documentation
- ✅ Bearer token authentication (dummy token "123" for now)
- ✅ Dependency Injection
- ✅ Type-safe domain models
- ✅ RESTful API endpoints

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code (optional)

### Installation

1. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

2. **Build the solution:**
   ```bash
   dotnet build
   ```

3. **Run the API:**
   ```bash
   cd FrankCrumCrm.Api
   dotnet run
   ```

4. **Access Swagger UI:**
   - Navigate to `http://localhost:5000` or `https://localhost:5001`
   - Swagger UI will be available at the root URL

## Authentication

The API is protected with Bearer token authentication. For now, use the dummy token **"123"**.

### Using Swagger UI

1. Click the **"Authorize"** button in Swagger UI
2. Enter: `Bearer 123` (include the word "Bearer" and a space)
3. Click **"Authorize"** and then **"Close"**

### Using cURL

```bash
curl -X GET "http://localhost:5000/api/v1/ClientData/123" \
  -H "Authorization: Bearer 123"
```

### Using Postman/HTTP Client

```
GET http://localhost:5000/api/v1/ClientData/123
Authorization: Bearer 123
```

## API Endpoints

### Client Data

- `GET /api/v1/ClientData/{id}` - Get client data by ID
- `GET /api/v1/ClientData/{clientNumber}/division/numbers` - Get division numbers
- `POST /api/v1/ClientData/payrollprocessingstatusclients` - Get payroll processing status
- `GET /api/v1/ClientData/pi-screen/{id}` - Get PI screen client information

### Payroll Managers

- `GET /api/v1/Users/PayrollManagers` - Get all payroll managers

### Onboarding Automation

- `GET /api/v1/OnboardingAutomation` - Get all onboarding automations
- `GET /api/v1/OnboardingAutomation/{id}` - Get onboarding automation by ID
- `POST /api/v1/OnboardingAutomation` - Create new onboarding automation
- `PUT /api/v1/OnboardingAutomation/{id}` - Update onboarding automation
- `DELETE /api/v1/OnboardingAutomation/{id}` - Delete onboarding automation

## Configuration

Update `appsettings.json` to configure the external CRM API:

```json
{
  "CrmApi": {
    "BaseUrl": "https://api.example.com",
    "BearerToken": ""
  }
}
```

## Project Structure

```
FrankCrumCrm.Api/
├── Controllers/              # API Controllers
│   ├── ClientDataController.cs
│   ├── PayrollManagerController.cs
│   └── OnboardingAutomationController.cs
├── Program.cs                # Application entry point
└── appsettings.json          # Configuration

FrankCrumCrm.Application/
├── DTOs/                     # Data Transfer Objects
│   └── CreateOnboardingRequest.cs
├── Interfaces/               # Application interfaces
│   └── ICrmApiClient.cs
└── Services/                 # Application services
    └── CrmService.cs

FrankCrumCrm.Domain/
└── Entities/                 # Domain entities
    ├── ClientData.cs
    ├── PIScreenClientInformation.cs
    ├── PayrollManager.cs
    └── EmployerOnbTemplatesProcessed.cs

FrankCrumCrm.Infrastructure/
└── Clients/                  # External API clients
    └── CrmApiClient.cs
```

## Development

### Adding New Endpoints

1. **Domain Layer**: Add entity in `FrankCrumCrm.Domain/Entities/`
2. **Application Layer**: Add method to `ICrmApiClient` interface and `CrmService`
3. **Infrastructure Layer**: Implement in `CrmApiClient`
4. **API Layer**: Add controller endpoint

### Example: Adding a New Endpoint

```csharp
// 1. Domain/Entities/NewEntity.cs
public class NewEntity { ... }

// 2. Application/Interfaces/ICrmApiClient.cs
Task<NewEntity> GetNewEntityAsync(int id);

// 3. Application/Services/CrmService.cs
public async Task<NewEntity> GetNewEntityAsync(int id)
{
    return await _apiClient.GetNewEntityAsync(id);
}

// 4. Infrastructure/Clients/CrmApiClient.cs
public async Task<NewEntity> GetNewEntityAsync(int id)
{
    return await GetAsync<NewEntity>($"/api/v1/NewEntity/{id}");
}

// 5. Api/Controllers/NewEntityController.cs
[HttpGet("{id}")]
public async Task<IActionResult> GetNewEntity(int id)
{
    var result = await _crmService.GetNewEntityAsync(id);
    return Ok(result);
}
```

## Dependencies

- **.NET 8.0**
- **Swashbuckle.AspNetCore** (6.5.0) - Swagger/OpenAPI
- **Microsoft.AspNetCore.Authentication.JwtBearer** (8.0.0) - JWT Authentication
- **Newtonsoft.Json** (13.0.3) - JSON serialization
- **Microsoft.Extensions.Http** (8.0.0) - HTTP client factory

## Testing the API

### Using Swagger UI

1. Start the application
2. Navigate to the Swagger UI
3. Click "Authorize" and enter `Bearer 123`
4. Try the endpoints directly from the UI

### Using HTTP Client

```bash
# Get client data
curl -X GET "http://localhost:5000/api/v1/ClientData/123" \
  -H "Authorization: Bearer 123"

# Get payroll managers
curl -X GET "http://localhost:5000/api/v1/Users/PayrollManagers" \
  -H "Authorization: Bearer 123"
```

## License

ISC
