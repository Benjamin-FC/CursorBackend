using FluentAssertions;
using FrankCrumCrm.Application.DTOs;
using FrankCrumCrm.Domain.Entities;
using FrankCrumCrm.Infrastructure.Clients;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace FrankCrumCrm.Tests.Infrastructure
{
    public class CrmApiClientTests
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly CrmApiClient _crmApiClient;

        public CrmApiClientTests()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.example.com")
            };
            _crmApiClient = new CrmApiClient(_httpClient);
        }

        [Fact]
        public async Task GetClientDataAsync_ShouldReturnClientData()
        {
            // Arrange
            var expectedClient = new ClientData
            {
                ClientId = "123",
                ClientLegalName = "Test Client"
            };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedClient), Encoding.UTF8, "application/json")
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri!.ToString().Contains("/api/v1/ClientData/123")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _crmApiClient.GetClientDataAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.ClientId.Should().Be("123");
            result.ClientLegalName.Should().Be("Test Client");
        }

        [Fact]
        public async Task GetDivisionNumbersAsync_ShouldReturnDivisionNumbers()
        {
            // Arrange
            var expectedDivisions = new List<string> { "DIV1", "DIV2" };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedDivisions), Encoding.UTF8, "application/json")
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri!.ToString().Contains("/api/v1/ClientData/123/division/numbers")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _crmApiClient.GetDivisionNumbersAsync(123);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().Contain("DIV1");
            result.Should().Contain("DIV2");
        }

        [Fact]
        public async Task GetPayrollManagersAsync_ShouldReturnManagers()
        {
            // Arrange
            var expectedManagers = new List<PayrollManager>
            {
                new PayrollManager { Id = 1, Name = "Manager 1" }
            };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedManagers), Encoding.UTF8, "application/json")
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri!.ToString().Contains("/api/v1/Users/PayrollManagers")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _crmApiClient.GetPayrollManagersAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
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
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedEntity), Encoding.UTF8, "application/json")
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Post &&
                        req.RequestUri!.ToString().Contains("/api/v1/OnboardingAutomation")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _crmApiClient.CreateOnboardingAutomationAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.ClientNumber.Should().Be("123");
        }

        [Fact]
        public async Task UpdateOnboardingAutomationAsync_ShouldReturnTrue()
        {
            // Arrange
            var request = new CreateOnboardingRequest { ClientNumber = "123" };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(true), Encoding.UTF8, "application/json")
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Put &&
                        req.RequestUri!.ToString().Contains("/api/v1/OnboardingAutomation/1")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _crmApiClient.UpdateOnboardingAutomationAsync(1, request);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteOnboardingAutomationAsync_ShouldReturnTrue()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(true), Encoding.UTF8, "application/json")
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Delete &&
                        req.RequestUri!.ToString().Contains("/api/v1/OnboardingAutomation/1")),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _crmApiClient.DeleteOnboardingAutomationAsync(1);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void SetBearerToken_ShouldSetAuthorizationHeader()
        {
            // Arrange
            var token = "test-token-123";
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.example.com")
            };
            var client = new CrmApiClient(httpClient);

            // Act
            client.SetBearerToken(token);

            // Assert
            httpClient.DefaultRequestHeaders.Authorization.Should().NotBeNull();
            httpClient.DefaultRequestHeaders.Authorization!.Scheme.Should().Be("Bearer");
            httpClient.DefaultRequestHeaders.Authorization.Parameter.Should().Be(token);
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenHttpClientIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CrmApiClient(null!));
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenBaseAddressIsNull()
        {
            // Arrange
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => new CrmApiClient(httpClient));
        }
    }
}
