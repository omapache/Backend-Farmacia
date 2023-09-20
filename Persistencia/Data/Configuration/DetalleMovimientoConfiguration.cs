
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
        builder.ToTable("detalleMovimiento");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.Property(e => e.Precio)
        .HasColumnName("precio")
        .HasColumnType("double")
       /*  .HasMaxLength(3) */
        .IsRequired();

        builder.HasOne(p => p.InventarioMedicamento)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.InventMedicamentoIdFk);

        builder.HasOne(p => p.MovimientoInventario)
        .WithMany(p => p.DetalleMovimientos)
        .HasForeignKey(p => p.MovInventarioIdFk);
    }
}
