using System;

namespace MinhaApp.Application.DTOs
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public Guid CategoriaId { get; set; }
    }
}
