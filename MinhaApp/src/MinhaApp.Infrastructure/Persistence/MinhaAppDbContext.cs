using Microsoft.EntityFrameworkCore;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Infrastructure.Persistence
{
    public class MinhaAppDbContext : DbContext
    {
        public MinhaAppDbContext(DbContextOptions<MinhaAppDbContext> options) : base(options)
        {
        }

        public DbSet<ExemploEntity> Exemplos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais podem ser feitas aqui
        }
    }
}