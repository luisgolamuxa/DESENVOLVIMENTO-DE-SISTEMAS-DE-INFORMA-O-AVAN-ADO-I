using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaApp.Application.DTOs;

namespace MinhaApp.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> CreateAsync(CategoriaDto dto);
        Task<CategoriaDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CategoriaDto>> GetAllAsync();
        Task UpdateAsync(CategoriaDto dto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<CategoriaDto>> SearchByNameAsync(string termo);
    }
}
