
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoMovimientoInventarioConfiguration : IEntityTypeConfiguration<TipoMovimientoInventario>
{
    public void Configure(EntityTypeBuilder<TipoMovimientoInventario> builder)
    {
        builder.ToTable("tipoMovimientoInventario");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();


    }
}
