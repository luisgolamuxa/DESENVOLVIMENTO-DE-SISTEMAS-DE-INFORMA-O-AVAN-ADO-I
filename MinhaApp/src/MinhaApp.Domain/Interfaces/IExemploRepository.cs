using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Domain.Interfaces
{
    public interface IExemploRepository
    {
        Task AddAsync(ExemploEntity exemplo);
        Task UpdateAsync(ExemploEntity exemplo);
        Task DeleteAsync(Guid id);
        Task<ExemploEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<ExemploEntity>> GetAllAsync();
    }
}