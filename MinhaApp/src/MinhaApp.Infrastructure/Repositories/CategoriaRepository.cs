using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;
using MinhaApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MinhaApp.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MinhaAppDbContext _context;

        public CategoriaRepository(MinhaAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CategoriaEntity categoria)
        {
            await _context.Set<CategoriaEntity>().AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cat = await GetByIdAsync(id);
            if (cat != null)
            {
                _context.Set<CategoriaEntity>().Remove(cat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoriaEntity>> GetAllAsync()
        {
            return await _context.Set<CategoriaEntity>().Include(c => c.Produtos).ToListAsync();
        }

        public async Task<CategoriaEntity?> GetByIdAsync(Guid id)
        {
            var item = await _context.Set<CategoriaEntity>().Include(c => c.Produtos).FirstOrDefaultAsync(c => c.Id == id);
            return item;
        }

        public async Task UpdateAsync(CategoriaEntity categoria)
        {
            _context.Set<CategoriaEntity>().Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoriaEntity>> SearchByNameAsync(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return await GetAllAsync();

            return await _context.Set<CategoriaEntity>()
                .Where(c => c.Nome.Contains(termo))
                .Include(c => c.Produtos)
                .ToListAsync();
        }
    }
}
