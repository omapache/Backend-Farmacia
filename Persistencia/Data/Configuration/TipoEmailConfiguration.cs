using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoEmailConfiguration : IEntityTypeConfiguration<TipoEmail>
{
    public void Configure(EntityTypeBuilder<TipoEmail> builder)
    {
        builder.ToTable("tipoEmail");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(250)
        .IsRequired();
    }
}