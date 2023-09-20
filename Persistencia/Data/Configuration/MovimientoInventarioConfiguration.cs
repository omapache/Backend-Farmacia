
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<MovimientoInventario>
{
    public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
    {
        builder.ToTable("movimientoInventario");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.FechaMovimiento)
        .HasColumnName("fechaMovimiento")
        .HasColumnType("date")
        .IsRequired();
        
        builder.Property(e => e.FechaVencimiento)
        .HasColumnName("fechaVencimiento")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.FormaPago)
        .WithMany(p => p.MovimientoInventarios)
        .HasForeignKey(p => p.FormaPagoIdFk);

        builder.HasOne(p => p.TipoMovimientoInventario)
        .WithMany(p => p.MovimientoInventarios)
        .HasForeignKey(p => p.TipoMovInventIdFk);
        
        builder.HasOne(p => p.Responsable)
        .WithMany(p => p.MovimientoInventarios)
        .HasForeignKey(p => p.ResponsableIdFk);
        
        builder.HasOne(p => p.Receptor)
        .WithMany(p => p.MovimientoInventarios)
        .HasForeignKey(p => p.ReceptorIdFk);
        
    }
}
