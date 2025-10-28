using System;

namespace MinhaApp.Domain.Entities
{
    public class ExemploEntity
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public ExemploStatus Status { get; private set; }

        public ExemploEntity(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataCriacao = DateTime.UtcNow;
            Status = ExemploStatus.Ativo; // Estado inicial
        }

        public void AtualizarNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void AlterarStatus(ExemploStatus novoStatus)
        {
            Status = novoStatus;
        }
    }
}