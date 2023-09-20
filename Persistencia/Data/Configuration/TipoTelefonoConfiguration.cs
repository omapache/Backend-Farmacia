using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoTelefonoConfiguration : IEntityTypeConfiguration<TipoTelefono>
{
    public void Configure(EntityTypeBuilder<TipoTelefono> builder)
    {
        builder.ToTable("TipoTelefono");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(250)
        .IsRequired();
    }
}