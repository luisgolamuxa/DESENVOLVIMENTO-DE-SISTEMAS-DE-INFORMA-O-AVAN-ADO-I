using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Infrastructure.Configurations
{
    public class EfConfigurations : IEntityTypeConfiguration<ExemploEntity>
    {
        public void Configure(EntityTypeBuilder<ExemploEntity> builder)
        {
            builder.ToTable("Exemplos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            // Adicione outras configurações conforme necessário
        }
    }
}