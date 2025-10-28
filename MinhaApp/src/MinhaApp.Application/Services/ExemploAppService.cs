using System.Collections.Generic;
using System.Threading.Tasks;
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
        }

        public async Task<ExemploDto> CreateAsync(ExemploDto exemploDto)
        {
            var exemploEntity = new ExemploEntity
            {
                // Mapear propriedades de exemploDto para exemploEntity
            };

            await _exemploRepository.AddAsync(exemploEntity);
            return exemploDto; // Retornar o DTO após a criação
        }

        public async Task<ExemploDto> GetByIdAsync(int id)
        {
            var exemploEntity = await _exemploRepository.GetByIdAsync(id);
            if (exemploEntity == null) return null;

            var exemploDto = new ExemploDto
            {
                // Mapear propriedades de exemploEntity para exemploDto
            };

            return exemploDto;
        }

        public async Task<IEnumerable<ExemploDto>> GetAllAsync()
        {
            var exemploEntities = await _exemploRepository.GetAllAsync();
            var exemploDtos = new List<ExemploDto>();

            foreach (var exemplo in exemploEntities)
            {
                exemploDtos.Add(new ExemploDto
                {
                    // Mapear propriedades de exemplo para exemploDto
                });
            }

            return exemploDtos;
        }

        public async Task UpdateAsync(ExemploDto exemploDto)
        {
            var exemploEntity = await _exemploRepository.GetByIdAsync(exemploDto.Id);
            if (exemploEntity == null) return;

            // Mapear propriedades de exemploDto para exemploEntity
            await _exemploRepository.UpdateAsync(exemploEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var exemploEntity = await _exemploRepository.GetByIdAsync(id);
            if (exemploEntity == null) return;

            await _exemploRepository.DeleteAsync(exemploEntity);
        }
    }
}