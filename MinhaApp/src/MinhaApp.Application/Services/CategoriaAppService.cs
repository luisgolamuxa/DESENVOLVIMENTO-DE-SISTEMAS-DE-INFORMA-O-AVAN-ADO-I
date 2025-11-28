using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using MinhaApp.Application.DTOs;
using MinhaApp.Application.Interfaces;
using MinhaApp.Domain.Interfaces;

namespace MinhaApp.Application.Services
{
    public class CategoriaAppService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaAppService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaDto> CreateAsync(CategoriaDto dto)
        {
            var entity = dto.Adapt<MinhaApp.Domain.Entities.CategoriaEntity>();
            await _categoriaRepository.AddAsync(entity);
            return entity.Adapt<CategoriaDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            var list = await _categoriaRepository.GetAllAsync();
            var mapped = list.Adapt<IEnumerable<CategoriaDto>>();
            return mapped ?? System.Linq.Enumerable.Empty<CategoriaDto>();
        }

        public async Task<CategoriaDto?> GetByIdAsync(Guid id)
        {
            var e = await _categoriaRepository.GetByIdAsync(id);
            return e?.Adapt<CategoriaDto>();
        }

        public async Task<IEnumerable<CategoriaDto>> SearchByNameAsync(string termo)
        {
            var list = await _categoriaRepository.SearchByNameAsync(termo);
            var mapped = list.Adapt<IEnumerable<CategoriaDto>>();
            return mapped ?? System.Linq.Enumerable.Empty<CategoriaDto>();
        }

        public async Task UpdateAsync(CategoriaDto dto)
        {
            var entity = await _categoriaRepository.GetByIdAsync(dto.Id);
            if (entity == null) return;
            // aplicar mudança no agregado via método de domínio
            entity.AtualizarNome(dto.Nome);
            await _categoriaRepository.UpdateAsync(entity);
        }
    }
}
