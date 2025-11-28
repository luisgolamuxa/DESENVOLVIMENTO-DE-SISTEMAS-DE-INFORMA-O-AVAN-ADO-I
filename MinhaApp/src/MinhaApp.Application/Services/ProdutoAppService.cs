using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using MinhaApp.Application.Mapping;
using MinhaApp.Application.DTOs;
using MinhaApp.Application.Interfaces;
using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;

namespace MinhaApp.Application.Services
{
    public class ProdutoAppService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            MapsterConfig.RegisterMappings();
        }

        public async Task<ProdutoDto> CreateAsync(ProdutoDto dto)
        {
            var entity = new ProdutoEntity(dto.Nome ?? string.Empty, dto.CategoriaId);
            await _produtoRepository.AddAsync(entity);
            return new ProdutoDto { Id = entity.Id, Nome = entity.Nome, CategoriaId = entity.CategoriaId };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _produtoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var items = await _produtoRepository.GetAllAsync();
            return items.Select(p => new ProdutoDto { Id = p.Id, Nome = p.Nome, CategoriaId = p.CategoriaId });
        }

        public async Task<ProdutoDto?> GetByIdAsync(Guid id)
        {
            var p = await _produtoRepository.GetByIdAsync(id);
            if (p == null) return null;
            return new ProdutoDto { Id = p.Id, Nome = p.Nome, CategoriaId = p.CategoriaId };
        }

        public async Task UpdateAsync(ProdutoDto dto)
        {
            var entity = await _produtoRepository.GetByIdAsync(dto.Id);
            if (entity == null) return;
            entity.AtualizarNome(dto.Nome);
            await _produtoRepository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<ProdutoDto>> GetByCategoriaAsync(Guid categoriaId)
        {
            var items = await _produtoRepository.GetByCategoriaIdAsync(categoriaId);
            return items.Select(p => new ProdutoDto { Id = p.Id, Nome = p.Nome, CategoriaId = p.CategoriaId });
        }
    }
}
