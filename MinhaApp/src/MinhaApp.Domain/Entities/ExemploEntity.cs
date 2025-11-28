using System;

namespace MinhaApp.Domain.Entities
{
    public class ExemploEntity
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Descricao { get; private set; } = null!;
        public DateTime DataCriacao { get; private set; }
        public ExemploStatus Status { get; private set; }

        // Construtor usado pelo EF
        private ExemploEntity() { }

        public ExemploEntity(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;
            Status = ExemploStatus.Ativo;
        }

        // Backwards-compatible constructor: aceita apenas nome
        public ExemploEntity(string nome) : this(nome, string.Empty)
        {
        }

        public void Atualizar(string novoNome, string novaDescricao)
        {
            Nome = novoNome;
            Descricao = novaDescricao;
        }

        public void AlterarStatus(ExemploStatus novoStatus)
        {
            Status = novoStatus;
        }
    }
}