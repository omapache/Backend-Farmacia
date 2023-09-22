using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TelefonoConfiguration : IEntityTypeConfiguration<Telefono>
{
    public void Configure(EntityTypeBuilder<Telefono> builder)
    {
        builder.ToTable("telefono");

        builder.Property(d => d.Numero)
        .HasColumnName("numero")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.HasOne(p => p.TipoTelefono)
        .WithMany(p => p.Telefonos)
        .HasForeignKey(p => p.TipoTelefonoIdFk);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Telefonos)
        .HasForeignKey(p => p.PersonaIdFk);
    }
}