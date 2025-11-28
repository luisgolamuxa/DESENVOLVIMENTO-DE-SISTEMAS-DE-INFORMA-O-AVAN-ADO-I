using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;
using MinhaApp.Infrastructure.Persistence;

namespace MinhaApp.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MinhaAppDbContext _db;

        public ProdutoRepository(MinhaAppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ProdutoEntity produto)
        {
            _db.Produtos.Add(produto);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var p = await _db.Produtos.FindAsync(id);
            if (p == null) return;
            _db.Produtos.Remove(p);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProdutoEntity>> GetAllAsync()
        {
            return await _db.Produtos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<ProdutoEntity?> GetByIdAsync(Guid id)
        {
            return await _db.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProdutoEntity>> GetByCategoriaIdAsync(Guid categoriaId)
        {
            return await _db.Produtos.Where(p => p.CategoriaId == categoriaId).ToListAsync();
        }

        public async Task UpdateAsync(ProdutoEntity produto)
        {
            _db.Produtos.Update(produto);
            await _db.SaveChangesAsync();
        }
    }
}
