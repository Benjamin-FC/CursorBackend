using FluentAssertions;
using FrankCrumCrm.Api.Controllers;
using FrankCrumCrm.Application.Services;
using FrankCrumCrm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FrankCrumCrm.Tests.Controllers
{
    public class PayrollManagerControllerTests
    {
        private readonly Mock<CrmService> _mockCrmService;
        private readonly PayrollManagerController _controller;

        public PayrollManagerControllerTests()
        {
            _mockCrmService = new Mock<CrmService>(Mock.Of<Application.Interfaces.ICrmApiClient>());
            _controller = new PayrollManagerController(_mockCrmService.Object);
        }

        [Fact]
        public async Task GetPayrollManagers_ShouldReturnOk()
        {
            // Arrange
            var expectedManagers = new List<PayrollManager>
            {
                new PayrollManager { Id = 1, Name = "Manager 1" },
                new PayrollManager { Id = 2, Name = "Manager 2" }
            };
            _mockCrmService.Setup(x => x.GetPayrollManagersAsync())
                .ReturnsAsync(expectedManagers);

            // Act
            var result = await _controller.GetPayrollManagers();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var managers = okResult.Value.Should().BeAssignableTo<List<PayrollManager>>().Subject;
            managers.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetPayrollManagers_ShouldReturn500_WhenExceptionOccurs()
        {
            // Arrange
            _mockCrmService.Setup(x => x.GetPayrollManagersAsync())
                .ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetPayrollManagers();

            // Assert
            var statusResult = result.Should().BeOfType<ObjectResult>().Subject;
            statusResult.StatusCode.Should().Be(500);
        }
    }
}
