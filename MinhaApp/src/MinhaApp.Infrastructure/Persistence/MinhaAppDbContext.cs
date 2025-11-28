using Microsoft.EntityFrameworkCore;
using MinhaApp.Domain.Entities;
using MinhaApp.Infrastructure.Configurations;

namespace MinhaApp.Infrastructure.Persistence
{
    public class MinhaAppDbContext : DbContext
    {
        public MinhaAppDbContext(DbContextOptions<MinhaAppDbContext> options) : base(options)
        {
        }

        public DbSet<ExemploEntity> Exemplos { get; set; }
        public DbSet<MinhaApp.Domain.Entities.CategoriaEntity> Categorias { get; set; }
        public DbSet<MinhaApp.Domain.Entities.ProdutoEntity> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EfConfigurations());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }
    }
}