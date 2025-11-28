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

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            builder.Property(e => e.Descricao)
                .HasMaxLength(500)
                .HasColumnName("Descricao");

            builder.Property(e => e.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasColumnName("Status");
        }
    }
}