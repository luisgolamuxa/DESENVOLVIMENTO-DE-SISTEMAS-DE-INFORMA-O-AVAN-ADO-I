using System;

namespace MinhaApp.Application.DTOs
{
    public class ExemploDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
    }
}