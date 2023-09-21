using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class InventarioMedicamentoConfiguration : IEntityTypeConfiguration<InventarioMedicamento>
{
    public void Configure(EntityTypeBuilder<InventarioMedicamento> builder)
    {
        builder.ToTable("inventarioMedicamento");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();

        builder.Property(e => e.Stock)
        .HasColumnName("stock")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();

        builder.Property(e => e.FechaExpiracion)
        .HasColumnName("fechaExpiracion")
        .HasColumnType("date")
        .HasMaxLength(256)
        .IsRequired();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.InventarioMedicamentos)
        .HasForeignKey(p => p.PersonaIdFk);

        builder.HasOne(p => p.TipoPresentacion)
        .WithMany(p => p.InventarioMedicamentos)
        .HasForeignKey(p => p.TipoPresentacionIdFk);
    }
}