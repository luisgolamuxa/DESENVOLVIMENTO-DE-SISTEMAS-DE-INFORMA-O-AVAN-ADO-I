using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MinhaApp.Api;
using MinhaApp.Application.Interfaces;
using MinhaApp.Application.DTOs;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MinhaApp.Api.Tests
{
    public class ExemploControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly Mock<IExemploService> _exemploServiceMock;

        public ExemploControllerTests(WebApplicationFactory<Startup> factory)
        {
            _exemploServiceMock = new Mock<IExemploService>();
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => _exemploServiceMock.Object);
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetExemplo_ReturnsOkResult()
        {
            // Arrange
            var exemploDto = new ExemploDto { Id = 1, Nome = "Exemplo" };
            _exemploServiceMock.Setup(service => service.GetExemploAsync(1)).ReturnsAsync(exemploDto);

            // Act
            var response = await _client.GetAsync("/api/exemplo/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateExemplo_ReturnsCreatedResult()
        {
            // Arrange
            var exemploDto = new ExemploDto { Nome = "Novo Exemplo" };
            _exemploServiceMock.Setup(service => service.CreateExemploAsync(exemploDto)).ReturnsAsync(1);

            // Act
            var response = await _client.PostAsJsonAsync("/api/exemplo", exemploDto);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task UpdateExemplo_ReturnsNoContentResult()
        {
            // Arrange
            var exemploDto = new ExemploDto { Id = 1, Nome = "Exemplo Atualizado" };
            _exemploServiceMock.Setup(service => service.UpdateExemploAsync(exemploDto)).Returns(Task.CompletedTask);

            // Act
            var response = await _client.PutAsJsonAsync("/api/exemplo", exemploDto);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteExemplo_ReturnsNoContentResult()
        {
            // Arrange
            _exemploServiceMock.Setup(service => service.DeleteExemploAsync(1)).Returns(Task.CompletedTask);

            // Act
            var response = await _client.DeleteAsync("/api/exemplo/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}