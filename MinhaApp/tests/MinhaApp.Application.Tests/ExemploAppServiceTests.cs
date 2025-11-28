using Xunit;
using Moq;
using MinhaApp.Application.Services;
using MinhaApp.Application.Interfaces;
using MinhaApp.Application.DTOs;
using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;
using System.Threading.Tasks;

namespace MinhaApp.Application.Tests
{
    public class ExemploAppServiceTests
    {
        private readonly Mock<IExemploRepository> _exemploRepositoryMock;
        private readonly IExemploService _exemploService;

        public ExemploAppServiceTests()
        {
            _exemploRepositoryMock = new Mock<IExemploRepository>();
            _exemploService = new ExemploAppService(_exemploRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateExemplo_ShouldAddExemplo_WhenValidData()
        {
            // Arrange
            var exemploEntity = new ExemploEntity("Teste");
            _exemploRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<ExemploEntity>()))
                                  .Returns(Task.CompletedTask);

            var dto = new ExemploDto { Nome = "Teste" };

            // Act
            var result = await _exemploService.CreateAsync(dto);

            // Assert
            Assert.NotNull(result);
            _exemploRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<ExemploEntity>()), Times.Once);
        }

        // Additional tests for other CRUD operations can be added here
    }
}