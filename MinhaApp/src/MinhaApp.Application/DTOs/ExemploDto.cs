using System;
using System.ComponentModel.DataAnnotations;
using MinhaApp.Application.Validation;

namespace MinhaApp.Application.DTOs
{
    public class ExemploDto
    {
        public Guid Id { get; set; }

        [Required]
        [NomeNaoVazio]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [DescricaoMinima(5)]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; } = null!;

        public DateTime DataCriacao { get; set; }
        public string? Status { get; set; }
    }
}