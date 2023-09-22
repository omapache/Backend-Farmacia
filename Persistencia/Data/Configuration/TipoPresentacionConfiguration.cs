using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoPresentacionConfiguration : IEntityTypeConfiguration<TipoPresentacion>
{
    public void Configure(EntityTypeBuilder<TipoPresentacion> builder)
    {
        builder.ToTable("tipoPresentacion");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();
    }
}
