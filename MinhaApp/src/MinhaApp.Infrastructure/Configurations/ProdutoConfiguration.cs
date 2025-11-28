using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Infrastructure.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CategoriaId)
                .IsRequired();
        }
    }
}
