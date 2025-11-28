using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MinhaApp.Api;
using MinhaApp.Application.Interfaces;
using MinhaApp.Application.DTOs;
using Moq;
using System.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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
                    // Remove existing registration and replace with mock
                    var existing = services.SingleOrDefault(d => d.ServiceType == typeof(IExemploService));
                    if (existing != null) services.Remove(existing);
                    services.AddScoped<IExemploService>(_ => _exemploServiceMock.Object);
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetExemplo_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var exemploDto = new ExemploDto { Id = id, Nome = "Exemplo" };
            _exemploServiceMock.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(exemploDto);

            // Act
            var response = await _client.GetAsync($"/api/exemplo/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateExemplo_ReturnsCreatedResult()
        {
            // Arrange
            var exemploDto = new ExemploDto { Nome = "Novo Exemplo", Descricao = "Descrição teste" };
            var created = new ExemploDto { Id = Guid.NewGuid(), Nome = exemploDto.Nome };
            _exemploServiceMock.Setup(service => service.CreateAsync(It.IsAny<ExemploDto>())).ReturnsAsync(created);

            // Act
            var response = await _client.PostAsJsonAsync("/api/exemplo", exemploDto);

            // Assert
            if (response.StatusCode != HttpStatusCode.Created)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new Xunit.Sdk.XunitException($"Expected 201 Created but got {(int)response.StatusCode}: {body}");
            }
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task UpdateExemplo_ReturnsNoContentResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var exemploDto = new ExemploDto { Id = id, Nome = "Exemplo Atualizado", Descricao = "Descricao atualizada" };
            _exemploServiceMock.Setup(service => service.UpdateAsync(It.IsAny<ExemploDto>())).Returns(Task.CompletedTask);

            // Act
            var response = await _client.PutAsJsonAsync($"/api/exemplo/{id}", exemploDto);

            // Assert
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                var body = await response.Content.ReadAsStringAsync();
                throw new Xunit.Sdk.XunitException($"Expected 204 NoContent but got {(int)response.StatusCode}: {body}");
            }
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteExemplo_ReturnsNoContentResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            _exemploServiceMock.Setup(service => service.DeleteAsync(id)).Returns(Task.CompletedTask);

            // Act
            var response = await _client.DeleteAsync($"/api/exemplo/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}