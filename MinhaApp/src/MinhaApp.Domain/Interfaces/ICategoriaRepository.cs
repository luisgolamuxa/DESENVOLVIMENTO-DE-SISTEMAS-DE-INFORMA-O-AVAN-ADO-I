using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task AddAsync(CategoriaEntity categoria);
        Task UpdateAsync(CategoriaEntity categoria);
        Task DeleteAsync(Guid id);
        Task<CategoriaEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoriaEntity>> GetAllAsync();
        Task<IEnumerable<CategoriaEntity>> SearchByNameAsync(string termo);
    }
}
