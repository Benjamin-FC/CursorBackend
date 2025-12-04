using FluentAssertions;
using FrankCrumCrm.Api.Controllers;
using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Application.Services;
using FrankCrumCrm.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FrankCrumCrm.Tests.Controllers
{
    public class ClientDataControllerTests
    {
        private readonly Mock<CrmService> _mockCrmService;
        private readonly ClientDataController _controller;

        public ClientDataControllerTests()
        {
            _mockCrmService = new Mock<CrmService>(Mock.Of<Application.Interfaces.ICrmApiClient>());
            _controller = new ClientDataController(_mockCrmService.Object);
        }

        [Fact]
        public async Task GetClientData_ShouldReturnOk_WhenDataExists()
        {
            // Arrange
            var expectedClient = new ClientData { ClientId = "123", ClientLegalName = "Test Client" };
            _mockCrmService.Setup(x => x.GetClientDataAsync(123))
                .ReturnsAsync(expectedClient);

            // Act
            var result = await _controller.GetClientData(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var clientData = okResult.Value.Should().BeOfType<ClientData>().Subject;
            clientData.ClientId.Should().Be("123");
        }

        [Fact]
        public async Task GetClientData_ShouldReturn500_WhenExceptionOccurs()
        {
            // Arrange
            _mockCrmService.Setup(x => x.GetClientDataAsync(123))
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetClientData(123);

            // Assert
            var statusResult = result.Should().BeOfType<ObjectResult>().Subject;
            statusResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task GetDivisionNumbers_ShouldReturnOk()
        {
            // Arrange
            var expectedDivisions = new List<string> { "DIV1", "DIV2" };
            _mockCrmService.Setup(x => x.GetDivisionNumbersAsync(123))
                .ReturnsAsync(expectedDivisions);

            // Act
            var result = await _controller.GetDivisionNumbers(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var divisions = okResult.Value.Should().BeAssignableTo<List<string>>().Subject;
            divisions.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetPayrollProcessingStatusClients_ShouldReturnOk()
        {
            // Arrange
            var clientIds = new List<string> { "123", "456" };
            var expectedClients = new List<ClientData>
            {
                new ClientData { ClientId = "123" }
            };
            _mockCrmService.Setup(x => x.GetPayrollProcessingStatusClientsAsync(clientIds))
                .ReturnsAsync(expectedClients);

            // Act
            var result = await _controller.GetPayrollProcessingStatusClients(clientIds);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPIScreenClientInformation_ShouldReturnOk()
        {
            // Arrange
            var expectedInfo = new PIScreenClientInformation { ClientId = "123" };
            _mockCrmService.Setup(x => x.GetPIScreenClientInformationAsync(123))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _controller.GetPIScreenClientInformation(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPIScreenBillingInformation_ShouldReturnOk()
        {
            // Arrange
            var expectedInfo = new PIScreenBillingInformation { ClientNumber = 123 };
            _mockCrmService.Setup(x => x.GetPIScreenBillingInformationAsync(123))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _controller.GetPIScreenBillingInformation(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWCSurcharges_ShouldReturnOk()
        {
            // Arrange
            var expectedSurcharges = new List<WCSurcharge>
            {
                new WCSurcharge { State = "FL", Amount = 100.0 }
            };
            _mockCrmService.Setup(x => x.GetWCSurchargesAsync(123))
                .ReturnsAsync(expectedSurcharges);

            // Act
            var result = await _controller.GetWCSurcharges(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPIScreenPayrollInformation_ShouldReturnOk()
        {
            // Arrange
            var expectedInfo = new PIScreenPayrollInformation { PayrollLevel = "Level 1" };
            _mockCrmService.Setup(x => x.GetPIScreenPayrollInformationAsync(123))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _controller.GetPIScreenPayrollInformation(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdatePIScreenNotes_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.UpdatePIScreenNotesAsync(123, "Test notes"))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdatePIScreenNotes(123, "Test notes");

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }

        [Fact]
        public async Task GetPayrollNotes_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.GetPayrollNotesAsync(123))
                .ReturnsAsync("Test notes");

            // Act
            var result = await _controller.GetPayrollNotes(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be("Test notes");
        }

        [Fact]
        public async Task UpdatePayrollNotes_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.UpdatePayrollNotesAsync(123, "Updated notes"))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdatePayrollNotes(123, "Updated notes");

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }

        [Fact]
        public async Task UpdateBillingNotes_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.UpdateBillingNotesAsync(123, "Billing notes"))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateBillingNotes(123, "Billing notes");

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }

        [Fact]
        public async Task GetBillingNotes_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.GetBillingNotesAsync(123))
                .ReturnsAsync("Billing notes");

            // Act
            var result = await _controller.GetBillingNotes(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be("Billing notes");
        }

        [Fact]
        public async Task GetEVerify_ShouldReturnOk()
        {
            // Arrange
            var expectedEVerify = new EVerify { EVerifyValue = "Yes" };
            _mockCrmService.Setup(x => x.GetEVerifyAsync(123))
                .ReturnsAsync(expectedEVerify);

            // Act
            var result = await _controller.GetEVerify(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetTerminatedClients_ShouldReturnOk()
        {
            // Arrange
            var clientIds = new List<string> { "123" };
            var expectedResult = new TerminatedClientsInformation
            {
                TerminatedClientIds = new List<int> { 123 }
            };
            _mockCrmService.Setup(x => x.GetTerminatedClientsAsync(clientIds))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GetTerminatedClients(clientIds);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPIScreenContacts_ShouldReturnOk()
        {
            // Arrange
            var expectedContacts = new List<PIScreenClientContact>
            {
                new PIScreenClientContact { ContactId = 1 }
            };
            _mockCrmService.Setup(x => x.GetPIScreenContactsAsync(123))
                .ReturnsAsync(expectedContacts);

            // Act
            var result = await _controller.GetPIScreenContacts(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetContactTypeLookup_ShouldReturnOk()
        {
            // Arrange
            var expectedLookup = new List<ContactTypeLookup>
            {
                new ContactTypeLookup { Id = Guid.NewGuid() }
            };
            _mockCrmService.Setup(x => x.GetContactTypeLookupAsync())
                .ReturnsAsync(expectedLookup);

            // Act
            var result = await _controller.GetContactTypeLookup();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPIScreenAdditionalContact_ShouldReturnOk()
        {
            // Arrange
            var expectedContact = new PIScreenAdditionalContact { FirstName = "John" };
            _mockCrmService.Setup(x => x.GetPIScreenAdditionalContactAsync(1))
                .ReturnsAsync(expectedContact);

            // Act
            var result = await _controller.GetPIScreenAdditionalContact(1);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOffsets_ShouldReturnOk()
        {
            // Arrange
            var expectedOffsets = new Offsets { ClientNumber = 123 };
            _mockCrmService.Setup(x => x.GetOffsetsAsync(123, "DIV1"))
                .ReturnsAsync(expectedOffsets);

            // Act
            var result = await _controller.GetOffsets(123, "DIV1");

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientPayrollInformation_ShouldReturnOk()
        {
            // Arrange
            var clientIds = new List<int> { 123 };
            var expectedInfo = new List<ClientPayrollInformation>
            {
                new ClientPayrollInformation { ClientNumber = 123 }
            };
            _mockCrmService.Setup(x => x.GetClientPayrollInformationAsync(clientIds))
                .ReturnsAsync(expectedInfo);

            // Act
            var result = await _controller.GetClientPayrollInformation(clientIds);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientProcessingTeam_ShouldReturnOk()
        {
            // Arrange
            var clientIds = new List<int> { 123 };
            var expectedTeam = new List<ClientProcessingTeam>
            {
                new ClientProcessingTeam { ClientNumber = 123 }
            };
            _mockCrmService.Setup(x => x.GetClientProcessingTeamAsync(clientIds))
                .ReturnsAsync(expectedTeam);

            // Act
            var result = await _controller.GetClientProcessingTeam(clientIds);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProcessingTeamContacts_ShouldReturnOk()
        {
            // Arrange
            var expectedContacts = new ProcessingTeamContacts();
            _mockCrmService.Setup(x => x.GetProcessingTeamContactsAsync(123))
                .ReturnsAsync(expectedContacts);

            // Act
            var result = await _controller.GetProcessingTeamContacts(123);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateClientPin_ShouldReturnOk()
        {
            // Arrange
            var request = new UpdateClientPinRequest
            {
                ClientPin = "1234",
                LegalEntityDivisionId = 1
            };
            _mockCrmService.Setup(x => x.UpdateClientPinAsync("CO123", request))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateClientPin("CO123", request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }

        [Fact]
        public async Task IsWOTCClient_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.IsWOTCClientAsync("CO123"))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.IsWOTCClient("CO123");

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }
    }
}
