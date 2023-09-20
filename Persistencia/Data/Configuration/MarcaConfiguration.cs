using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MarcaConfiguration: IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.ToTable("marca");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(256)
        .IsRequired();
    }
}
