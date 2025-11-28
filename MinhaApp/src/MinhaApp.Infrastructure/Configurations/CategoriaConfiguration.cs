using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Infrastructure.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
