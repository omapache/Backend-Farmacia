using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DescripcionMedicamentoConfiguration : IEntityTypeConfiguration<DescripcionMedicamento>
{
    public void Configure(EntityTypeBuilder<DescripcionMedicamento> builder)
    {
        builder.ToTable("descripcionMedicamento");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();

        builder.Property(e => e.CantidadMg)
        .HasColumnName("cantidadMg")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();

        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();

        builder.HasOne(p => p.TipoPresentacion)
        .WithMany(p => p.DescripcionMedicamentos)
        .HasForeignKey(p => p.TipoPresentacionIdFk); 
    }
}
