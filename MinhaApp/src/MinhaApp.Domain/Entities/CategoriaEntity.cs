using System;
using System.Collections.Generic;

namespace MinhaApp.Domain.Entities
{
    public class CategoriaEntity
    {
        private CategoriaEntity() { }

        public CategoriaEntity(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Produtos = new List<ProdutoEntity>();
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;

        public ICollection<ProdutoEntity> Produtos { get; private set; } = new List<ProdutoEntity>();

        public void AtualizarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome)) return;
            Nome = novoNome.Trim();
        }

        public ProdutoEntity AdicionarProduto(string nomeProduto)
        {
            if (string.IsNullOrWhiteSpace(nomeProduto))
                throw new ArgumentException("Nome do produto inválido.", nameof(nomeProduto));

            var produto = new ProdutoEntity(nomeProduto, Id);
            Produtos.Add(produto);
            return produto;
        }

        public void RemoverProduto(Guid produtoId)
        {
            var existente = Produtos.FirstOrDefault(p => p.Id == produtoId);
            if (existente != null)
            {
                Produtos.Remove(existente);
            }
        }
    }
}
