using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using MinhaApp.Application.DTOs;
using MinhaApp.Application.Interfaces;
using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;

namespace MinhaApp.Application.Services
{
    public class ExemploAppService : IExemploService
    {
        private readonly IExemploRepository _exemploRepository;

        public ExemploAppService(IExemploRepository exemploRepository)
        {
            _exemploRepository = exemploRepository;
            // Ensure Mapster mappings are registered for unit tests and non-web hosts
            MinhaApp.Application.Mapping.MapsterConfig.RegisterMappings();
        }

        public async Task<ExemploDto> CreateAsync(ExemploDto exemploDto)
        {
            // Constrói explicitamente a entidade para evitar dependência de mapeamento em tempo de teste
            var exemploEntity = new ExemploEntity(exemploDto.Nome ?? string.Empty, exemploDto.Descricao ?? string.Empty);
            await _exemploRepository.AddAsync(exemploEntity);
            var created = new ExemploDto
            {
                Id = exemploEntity.Id,
                Nome = exemploEntity.Nome,
                Descricao = exemploEntity.Descricao,
                DataCriacao = exemploEntity.DataCriacao,
                Status = exemploEntity.Status.ToString()
            };
            return created;
        }

        public async Task<ExemploDto?> GetByIdAsync(Guid id)
        {
            var exemploEntity = await _exemploRepository.GetByIdAsync(id);
            if (exemploEntity == null) return null;
            return exemploEntity.Adapt<ExemploDto>();
        }

        public async Task<IEnumerable<ExemploDto>> GetAllAsync()
        {
            var exemploEntities = await _exemploRepository.GetAllAsync();
            var mapped = exemploEntities.Adapt<IEnumerable<ExemploDto>>();
            return mapped ?? System.Linq.Enumerable.Empty<ExemploDto>();
        }

        public async Task UpdateAsync(ExemploDto exemploDto)
        {
            var exemploEntity = await _exemploRepository.GetByIdAsync(exemploDto.Id);
            if (exemploEntity == null) return;

            exemploEntity.Atualizar(exemploDto.Nome, exemploDto.Descricao);
            await _exemploRepository.UpdateAsync(exemploEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var exemploEntity = await _exemploRepository.GetByIdAsync(id);
            if (exemploEntity == null) return;

            await _exemploRepository.DeleteAsync(id);
        }
    }
}