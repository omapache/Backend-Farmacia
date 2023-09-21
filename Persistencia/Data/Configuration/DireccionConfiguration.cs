using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("direccion");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id);

        builder.Property(d => d.CallePrincipal)
        .HasColumnName("callePrincipal")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.Property(d => d.CalleSecundaria)
        .HasColumnName("calleSecundaria")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.Property(d => d.Numero)
        .HasColumnName("numero")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(150);

        builder.Property(d => d.Descripcion)
        .HasColumnName("descripcion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.HasOne(d => d.Ciudad)
        .WithMany(d => d.Direcciones)
        .HasForeignKey(d => d.CiudadIdFk);

        builder.HasOne(d => d.Persona)
        .WithMany(d => d.Direcciones)
        .HasForeignKey(d => d.PersonaIdFk);
    }
}