using FluentAssertions;
using FrankCrumCrm.Api.Controllers;
using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Application.Services;
using FrankCrumCrm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FrankCrumCrm.Tests.Controllers
{
    public class OnboardingAutomationControllerTests
    {
        private readonly Mock<CrmService> _mockCrmService;
        private readonly OnboardingAutomationController _controller;

        public OnboardingAutomationControllerTests()
        {
            _mockCrmService = new Mock<CrmService>(Mock.Of<Application.Interfaces.ICrmApiClient>());
            _controller = new OnboardingAutomationController(_mockCrmService.Object);
        }

        [Fact]
        public async Task CreateOnboardingAutomation_ShouldReturnOk()
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
            _mockCrmService.Setup(x => x.CreateOnboardingAutomationAsync(request))
                .ReturnsAsync(expectedEntity);

            // Act
            var result = await _controller.CreateOnboardingAutomation(request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var entity = okResult.Value.Should().BeOfType<EmployerOnbTemplatesProcessed>().Subject;
            entity.Id.Should().Be(1);
        }

        [Fact]
        public async Task CreateOnboardingAutomation_ShouldReturn500_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CreateOnboardingRequest();
            _mockCrmService.Setup(x => x.CreateOnboardingAutomationAsync(request))
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.CreateOnboardingAutomation(request);

            // Assert
            var statusResult = result.Should().BeOfType<ObjectResult>().Subject;
            statusResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task GetAllOnboardingAutomations_ShouldReturnOk()
        {
            // Arrange
            var expectedEntities = new List<EmployerOnbTemplatesProcessed>
            {
                new EmployerOnbTemplatesProcessed { Id = 1 },
                new EmployerOnbTemplatesProcessed { Id = 2 }
            };
            _mockCrmService.Setup(x => x.GetAllOnboardingAutomationAsync())
                .ReturnsAsync(expectedEntities);

            // Act
            var result = await _controller.GetAllOnboardingAutomations();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetOnboardingAutomationById_ShouldReturnOk()
        {
            // Arrange
            var expectedEntity = new EmployerOnbTemplatesProcessed { Id = 1 };
            _mockCrmService.Setup(x => x.GetOnboardingAutomationByIdAsync(1))
                .ReturnsAsync(expectedEntity);

            // Act
            var result = await _controller.GetOnboardingAutomationById(1);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateOnboardingAutomation_ShouldReturnOk()
        {
            // Arrange
            var request = new CreateOnboardingRequest { ClientNumber = "123" };
            _mockCrmService.Setup(x => x.UpdateOnboardingAutomationAsync(1, request))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateOnboardingAutomation(1, request);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }

        [Fact]
        public async Task DeleteOnboardingAutomation_ShouldReturnOk()
        {
            // Arrange
            _mockCrmService.Setup(x => x.DeleteOnboardingAutomationAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteOnboardingAutomation(1);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().Be(true);
        }
    }
}
