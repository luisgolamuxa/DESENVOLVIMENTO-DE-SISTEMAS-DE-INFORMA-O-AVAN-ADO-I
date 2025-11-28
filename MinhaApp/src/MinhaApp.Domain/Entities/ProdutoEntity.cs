using System;

namespace MinhaApp.Domain.Entities
{
    public class ProdutoEntity
    {
        private ProdutoEntity() { }

        public ProdutoEntity(string nome, Guid categoriaId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CategoriaId = categoriaId;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;

        public Guid CategoriaId { get; private set; }
        public CategoriaEntity Categoria { get; private set; } = null!;
        
        public void AtualizarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome)) return;
            Nome = novoNome.Trim();
        }

        public void MoverParaCategoria(Guid novaCategoriaId)
        {
            if (novaCategoriaId == Guid.Empty) return;
            CategoriaId = novaCategoriaId;
        }
    }
}
