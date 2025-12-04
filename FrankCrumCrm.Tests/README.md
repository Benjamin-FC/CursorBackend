# FrankCrum CRM API - Test Project

This project contains comprehensive unit tests for the FrankCrum CRM API solution.

## Test Structure

### Services Tests
- **CrmServiceTests.cs**: Unit tests for the `CrmService` class covering all business logic methods
  - Tests for all CRUD operations
  - Tests for all client data retrieval methods
  - Tests for all PI screen operations
  - Tests for notes management
  - Tests for payroll and billing operations

### Controller Tests
- **ClientDataControllerTests.cs**: Unit tests for the `ClientDataController`
  - Tests for all GET endpoints
  - Tests for all POST endpoints
  - Tests for error handling (500 status codes)
  - Tests for successful responses (200 status codes)

- **OnboardingAutomationControllerTests.cs**: Unit tests for the `OnboardingAutomationController`
  - Tests for CRUD operations
  - Tests for error handling

- **PayrollManagerControllerTests.cs**: Unit tests for the `PayrollManagerController`
  - Tests for payroll manager retrieval
  - Tests for error handling

### Infrastructure Tests
- **CrmApiClientTests.cs**: Unit tests for the `CrmApiClient` class
  - Tests for HTTP GET operations
  - Tests for HTTP POST operations
  - Tests for HTTP PUT operations
  - Tests for HTTP DELETE operations
  - Tests for bearer token management
  - Tests for error handling and edge cases

### Test Helpers
- **TestDataBuilder.cs**: Utility class for creating test data objects
  - Builder methods for all domain entities
  - Builder methods for DTOs
  - Simplifies test setup and improves readability

## Test Frameworks and Libraries

- **xUnit**: Testing framework
- **Moq**: Mocking framework for creating test doubles
- **FluentAssertions**: Fluent assertion library for readable test assertions
- **Microsoft.AspNetCore.Mvc.Testing**: For integration testing (if needed)

## Running Tests

### Using .NET CLI
```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run tests with code coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Run specific test class
dotnet test --filter FullyQualifiedName~CrmServiceTests
```

### Using Visual Studio
1. Open Test Explorer (Test > Test Explorer)
2. Build the solution
3. Run All Tests or select specific tests

### Using Rider/VS Code
- Use the built-in test runner
- Tests will appear in the test explorer

## Test Coverage

The test suite provides comprehensive coverage for:
- ✅ All service methods (100% method coverage)
- ✅ All controller endpoints
- ✅ All infrastructure client methods
- ✅ Error handling scenarios
- ✅ Edge cases and null handling

## Test Patterns

### Arrange-Act-Assert (AAA) Pattern
All tests follow the AAA pattern:
```csharp
[Fact]
public async Task MethodName_ShouldReturnExpected_WhenCondition()
{
    // Arrange
    // Setup test data and mocks
    
    // Act
    // Execute the method under test
    
    // Assert
    // Verify the results
}
```

### Mocking Strategy
- **Services**: Mock `ICrmApiClient` interface
- **Controllers**: Mock `CrmService` class
- **Infrastructure**: Mock `HttpMessageHandler` for HTTP calls

## Adding New Tests

When adding new functionality:
1. Add corresponding tests in the appropriate test class
2. Use `TestDataBuilder` for creating test data
3. Follow the existing naming conventions
4. Ensure both success and error scenarios are covered

## Best Practices

1. **Isolation**: Each test should be independent
2. **Naming**: Use descriptive test method names
3. **Arrange**: Keep setup minimal and focused
4. **Assertions**: Use FluentAssertions for readable assertions
5. **Mocks**: Verify mock interactions when necessary
6. **Coverage**: Aim for high code coverage but focus on meaningful tests

## Continuous Integration

Tests are designed to run in CI/CD pipelines:
- Fast execution (unit tests only)
- No external dependencies
- Deterministic results
- Clear failure messages
