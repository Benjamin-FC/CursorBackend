using FluentAssertions;
using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Application.Interfaces;
using FrankCrumCrm.Application.Services;
using FrankCrumCrm.Domain.Entities;
using Moq;
using Xunit;

namespace FrankCrumCrm.Tests.Services
{
    public class CrmServiceTests
    {
        private readonly Mock<ICrmApiClient> _mockApiClient;
        private readonly CrmService _crmService;

        public CrmServiceTests()
        {
            _mockApiClient = new Mock<ICrmApiClient>();
            _crmService = new CrmService(_mockApiClient.Object);
        }

        [Fact]
        public async Task GetClientDataAsync_ShouldReturnClientData()
        {
            // Arrange
            var expectedClientData = new ClientData
            {
                ClientId = "123",
                ClientLegalName = "Test Client"
            };
            _mockApiClient.Setup(x => x.GetClientDataAsync(123))
                .ReturnsAsync(expectedClientData);

            // Act
            var result = await _crmService.GetClientDataAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.ClientId.Should().Be("123");
            result.ClientLegalName.Should().Be("Test Client");
            _mockApiClient.Verify(x => x.GetClientDataAsync(123), Times.Once);
        }

        [Fact]
        public async Task GetDivisionNumbersAsync_ShouldReturnDivisionNumbers()
        {
            // Arrange
            var expectedDivisions = new List<string> { "DIV1", "DIV2" };
            _mockApiClient.Setup(x => x.GetDivisionNumbersAsync(123))
                .ReturnsAsync(expectedDivisions);

            // Act
            var result = await _crmService.GetDivisionNumbersAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().Contain("DIV1");
            result.Should().Contain("DIV2");
        }

        [Fact]
        public async Task GetPayrollProcessingStatusClientsAsync_ShouldReturnClients()
        {
            // Arrange
            var clientIds = new List<string> { "123", "456" };
            var expectedClients = new List<ClientData>
            {
                new ClientData { ClientId = "123" },
                new ClientData { ClientId = "456" }
            };
            _mockApiClient.Setup(x => x.GetPayrollProcessingStatusClientsAsync(clientIds))
                .ReturnsAsync(expectedClients);

            // Act
            var result = await _crmService.GetPayrollProcessingStatusClientsAsync(clientIds);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetPIScreenClientInformationAsync_ShouldReturnInformation()
        {
            // Arrange
            var expectedInfo = new PIScreenClientInformation
            {
                ClientId = "123",
                ClientName = "Test Client"
            };
            _mockApiClient.Setup(x => x.GetPIScreenClientInformationAsync(123))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _crmService.GetPIScreenClientInformationAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.ClientId.Should().Be("123");
            result.ClientName.Should().Be("Test Client");
        }

        [Fact]
        public async Task GetPayrollManagersAsync_ShouldReturnManagers()
        {
            // Arrange
            var expectedManagers = new List<PayrollManager>
            {
                new PayrollManager { Id = 1, Name = "Manager 1" },
                new PayrollManager { Id = 2, Name = "Manager 2" }
            };
            _mockApiClient.Setup(x => x.GetPayrollManagersAsync())
                .ReturnsAsync(expectedManagers);

            // Act
            var result = await _crmService.GetPayrollManagersAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Fact]
        public async Task CreateOnboardingAutomationAsync_ShouldReturnCreatedEntity()
        {
            // Arrange
            var request = new CreateOnboardingRequest
            {
                ClientNumber = "123",
                ProcessedFlag = false
            };
            var expectedEntity = new EmployerOnbTemplatesProcessed
            {
                Id = 1,
                ClientNumber = "123"
            };
            _mockApiClient.Setup(x => x.CreateOnboardingAutomationAsync(request))
                .ReturnsAsync(expectedEntity);

            // Act
            var result = await _crmService.CreateOnboardingAutomationAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.ClientNumber.Should().Be("123");
        }

        [Fact]
        public async Task GetAllOnboardingAutomationAsync_ShouldReturnAllEntities()
        {
            // Arrange
            var expectedEntities = new List<EmployerOnbTemplatesProcessed>
            {
                new EmployerOnbTemplatesProcessed { Id = 1 },
                new EmployerOnbTemplatesProcessed { Id = 2 }
            };
            _mockApiClient.Setup(x => x.GetAllOnboardingAutomationAsync())
                .ReturnsAsync(expectedEntities);

            // Act
            var result = await _crmService.GetAllOnboardingAutomationAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetOnboardingAutomationByIdAsync_ShouldReturnEntity()
        {
            // Arrange
            var expectedEntity = new EmployerOnbTemplatesProcessed { Id = 1 };
            _mockApiClient.Setup(x => x.GetOnboardingAutomationByIdAsync(1))
                .ReturnsAsync(expectedEntity);

            // Act
            var result = await _crmService.GetOnboardingAutomationByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
        }

        [Fact]
        public async Task UpdateOnboardingAutomationAsync_ShouldReturnTrue()
        {
            // Arrange
            var request = new CreateOnboardingRequest { ClientNumber = "123" };
            _mockApiClient.Setup(x => x.UpdateOnboardingAutomationAsync(1, request))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.UpdateOnboardingAutomationAsync(1, request);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteOnboardingAutomationAsync_ShouldReturnTrue()
        {
            // Arrange
            _mockApiClient.Setup(x => x.DeleteOnboardingAutomationAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.DeleteOnboardingAutomationAsync(1);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetPIScreenBillingInformationAsync_ShouldReturnBillingInfo()
        {
            // Arrange
            var expectedInfo = new PIScreenBillingInformation
            {
                ClientNumber = 123,
                PaymentMethod = "Credit Card"
            };
            _mockApiClient.Setup(x => x.GetPIScreenBillingInformationAsync(123))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _crmService.GetPIScreenBillingInformationAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.ClientNumber.Should().Be(123);
            result.PaymentMethod.Should().Be("Credit Card");
        }

        [Fact]
        public async Task GetWCSurchargesAsync_ShouldReturnSurcharges()
        {
            // Arrange
            var expectedSurcharges = new List<WCSurcharge>
            {
                new WCSurcharge { State = "FL", Amount = 100.0 }
            };
            _mockApiClient.Setup(x => x.GetWCSurchargesAsync(123))
                .ReturnsAsync(expectedSurcharges);

            // Act
            var result = await _crmService.GetWCSurchargesAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].State.Should().Be("FL");
        }

        [Fact]
        public async Task GetPIScreenPayrollInformationAsync_ShouldReturnPayrollInfo()
        {
            // Arrange
            var expectedInfo = new PIScreenPayrollInformation
            {
                PayrollLevel = "Level 1"
            };
            _mockApiClient.Setup(x => x.GetPIScreenPayrollInformationAsync(123))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _crmService.GetPIScreenPayrollInformationAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.PayrollLevel.Should().Be("Level 1");
        }

        [Fact]
        public async Task UpdatePIScreenNotesAsync_ShouldReturnTrue()
        {
            // Arrange
            _mockApiClient.Setup(x => x.UpdatePIScreenNotesAsync(123, "Test notes"))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.UpdatePIScreenNotesAsync(123, "Test notes");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetPayrollNotesAsync_ShouldReturnNotes()
        {
            // Arrange
            var expectedNotes = "Test payroll notes";
            _mockApiClient.Setup(x => x.GetPayrollNotesAsync(123))
                .ReturnsAsync(expectedNotes);

            // Act
            var result = await _crmService.GetPayrollNotesAsync(123);

            // Assert
            result.Should().Be("Test payroll notes");
        }

        [Fact]
        public async Task UpdatePayrollNotesAsync_ShouldReturnTrue()
        {
            // Arrange
            _mockApiClient.Setup(x => x.UpdatePayrollNotesAsync(123, "Updated notes"))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.UpdatePayrollNotesAsync(123, "Updated notes");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateBillingNotesAsync_ShouldReturnTrue()
        {
            // Arrange
            _mockApiClient.Setup(x => x.UpdateBillingNotesAsync(123, "Billing notes"))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.UpdateBillingNotesAsync(123, "Billing notes");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task GetBillingNotesAsync_ShouldReturnNotes()
        {
            // Arrange
            var expectedNotes = "Billing notes";
            _mockApiClient.Setup(x => x.GetBillingNotesAsync(123))
                .ReturnsAsync(expectedNotes);

            // Act
            var result = await _crmService.GetBillingNotesAsync(123);

            // Assert
            result.Should().Be("Billing notes");
        }

        [Fact]
        public async Task GetEVerifyAsync_ShouldReturnEVerify()
        {
            // Arrange
            var expectedEVerify = new EVerify
            {
                EVerifyValue = "Yes",
                EVerifyState = "FL"
            };
            _mockApiClient.Setup(x => x.GetEVerifyAsync(123))
                .ReturnsAsync(expectedEVerify);

            // Act
            var result = await _crmService.GetEVerifyAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.EVerifyValue.Should().Be("Yes");
        }

        [Fact]
        public async Task GetTerminatedClientsAsync_ShouldReturnTerminatedClients()
        {
            // Arrange
            var clientIds = new List<string> { "123", "456" };
            var expectedResult = new TerminatedClientsInformation
            {
                TerminatedClientIds = new List<int> { 123, 456 }
            };
            _mockApiClient.Setup(x => x.GetTerminatedClientsAsync(clientIds))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _crmService.GetTerminatedClientsAsync(clientIds);

            // Assert
            result.Should().NotBeNull();
            result.TerminatedClientIds.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetPIScreenContactsAsync_ShouldReturnContacts()
        {
            // Arrange
            var expectedContacts = new List<PIScreenClientContact>
            {
                new PIScreenClientContact { ContactId = 1, Contact = "John Doe" }
            };
            _mockApiClient.Setup(x => x.GetPIScreenContactsAsync(123))
                .ReturnsAsync(expectedContacts);

            // Act
            var result = await _crmService.GetPIScreenContactsAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetContactTypeLookupAsync_ShouldReturnLookup()
        {
            // Arrange
            var expectedLookup = new List<ContactTypeLookup>
            {
                new ContactTypeLookup { Id = Guid.NewGuid(), ContactTypeName = "Primary" }
            };
            _mockApiClient.Setup(x => x.GetContactTypeLookupAsync())
                .ReturnsAsync(expectedLookup);

            // Act
            var result = await _crmService.GetContactTypeLookupAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetPIScreenAdditionalContactAsync_ShouldReturnContact()
        {
            // Arrange
            var expectedContact = new PIScreenAdditionalContact
            {
                FirstName = "John",
                LastName = "Doe"
            };
            _mockApiClient.Setup(x => x.GetPIScreenAdditionalContactAsync(1))
                .ReturnsAsync(expectedContact);

            // Act
            var result = await _crmService.GetPIScreenAdditionalContactAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.FirstName.Should().Be("John");
        }

        [Fact]
        public async Task GetOffsetsAsync_ShouldReturnOffsets()
        {
            // Arrange
            var expectedOffsets = new Offsets
            {
                ClientNumber = 123,
                DivisionNumber = "DIV1"
            };
            _mockApiClient.Setup(x => x.GetOffsetsAsync(123, "DIV1"))
                .ReturnsAsync(expectedOffsets);

            // Act
            var result = await _crmService.GetOffsetsAsync(123, "DIV1");

            // Assert
            result.Should().NotBeNull();
            result.ClientNumber.Should().Be(123);
        }

        [Fact]
        public async Task GetClientPayrollInformationAsync_ShouldReturnInformation()
        {
            // Arrange
            var clientIds = new List<int> { 123, 456 };
            var expectedInfo = new List<ClientPayrollInformation>
            {
                new ClientPayrollInformation { ClientNumber = 123 }
            };
            _mockApiClient.Setup(x => x.GetClientPayrollInformationAsync(clientIds))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _crmService.GetClientPayrollInformationAsync(clientIds);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetClientProcessingTeamAsync_ShouldReturnTeam()
        {
            // Arrange
            var clientIds = new List<int> { 123 };
            var expectedTeam = new List<ClientProcessingTeam>
            {
                new ClientProcessingTeam { ClientNumber = 123 }
            };
            _mockApiClient.Setup(x => x.GetClientProcessingTeamAsync(clientIds))
                .ReturnsAsync(expectedTeam);

            // Act
            var result = await _crmService.GetClientProcessingTeamAsync(clientIds);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetProcessingTeamContactsAsync_ShouldReturnContacts()
        {
            // Arrange
            var expectedContacts = new ProcessingTeamContacts();
            _mockApiClient.Setup(x => x.GetProcessingTeamContactsAsync(123))
                .ReturnsAsync(expectedContacts);

            // Act
            var result = await _crmService.GetProcessingTeamContactsAsync(123);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateClientPinAsync_ShouldReturnTrue()
        {
            // Arrange
            var request = new UpdateClientPinRequest
            {
                ClientPin = "1234",
                LegalEntityDivisionId = 1
            };
            _mockApiClient.Setup(x => x.UpdateClientPinAsync("CO123", request))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.UpdateClientPinAsync("CO123", request);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task IsWOTCClientAsync_ShouldReturnBoolean()
        {
            // Arrange
            _mockApiClient.Setup(x => x.IsWOTCClientAsync("CO123"))
                .ReturnsAsync(true);

            // Act
            var result = await _crmService.IsWOTCClientAsync("CO123");

            // Assert
            result.Should().BeTrue();
        }
    }
}
