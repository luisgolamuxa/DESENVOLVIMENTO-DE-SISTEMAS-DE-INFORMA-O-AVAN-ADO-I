using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task AddAsync(ProdutoEntity produto);
        Task UpdateAsync(ProdutoEntity produto);
        Task DeleteAsync(Guid id);
        Task<ProdutoEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutoEntity>> GetAllAsync();
        Task<IEnumerable<ProdutoEntity>> GetByCategoriaIdAsync(Guid categoriaId);
    }
}
