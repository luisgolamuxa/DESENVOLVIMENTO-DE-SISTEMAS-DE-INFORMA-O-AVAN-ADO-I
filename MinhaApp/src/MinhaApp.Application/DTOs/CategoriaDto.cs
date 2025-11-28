using System;
using System.Collections.Generic;

namespace MinhaApp.Application.DTOs
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public IEnumerable<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();
    }
}
