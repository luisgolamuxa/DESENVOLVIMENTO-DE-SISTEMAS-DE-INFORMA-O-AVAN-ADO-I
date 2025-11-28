using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaApp.Application.DTOs;

namespace MinhaApp.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDto> CreateAsync(ProdutoDto dto);
        Task<ProdutoDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task UpdateAsync(ProdutoDto dto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ProdutoDto>> GetByCategoriaAsync(Guid categoriaId);
    }
}
