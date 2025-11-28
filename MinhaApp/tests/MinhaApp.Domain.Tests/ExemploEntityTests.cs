using Xunit;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Domain.Tests
{
    public class ExemploEntityTests
    {
        [Fact]
        public void CriarExemploEntity_ValidaPropriedades()
        {
            // Arrange
            var exemplo = new ExemploEntity("Teste", "Descricao");

            // Act & Assert
            Assert.NotNull(exemplo);
            Assert.Equal("Teste", exemplo.Nome);
        }

        [Fact]
        public void ExemploEntity_Atualizar_AlteraValores()
        {
            // Arrange
            var exemplo = new ExemploEntity("Inicial", "Desc");

            // Act
            exemplo.Atualizar("Novo", "NovaDesc");

            // Assert
            Assert.Equal("Novo", exemplo.Nome);
            Assert.Equal("NovaDesc", exemplo.Descricao);
        }

        // Adicione mais testes conforme necessário
    }
}