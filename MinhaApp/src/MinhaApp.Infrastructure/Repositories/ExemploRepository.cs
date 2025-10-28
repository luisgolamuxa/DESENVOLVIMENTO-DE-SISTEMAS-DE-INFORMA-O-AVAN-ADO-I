using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;
using MinhaApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApp.Infrastructure.Repositories
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly MinhaAppDbContext _context;

        public ExemploRepository(MinhaAppDbContext context)
        {
            _context = context;
        }

        public async Task<ExemploEntity> GetByIdAsync(int id)
        {
            return await _context.Exemplos.FindAsync(id);
        }

        public async Task<IEnumerable<ExemploEntity>> GetAllAsync()
        {
            return await _context.Exemplos.ToListAsync();
        }

        public async Task AddAsync(ExemploEntity exemplo)
        {
            await _context.Exemplos.AddAsync(exemplo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExemploEntity exemplo)
        {
            _context.Exemplos.Update(exemplo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exemplo = await GetByIdAsync(id);
            if (exemplo != null)
            {
                _context.Exemplos.Remove(exemplo);
                await _context.SaveChangesAsync();
            }
        }
    }
}