using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EmailConfiguration : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("email");

        builder.Property(d => d.Direccion)
        .HasColumnName("direccion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(250);

        builder.HasOne(p => p.TipoEmail)
        .WithMany(p => p.Emails)
        .HasForeignKey(p => p.TipoEmailIdFk);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Emails)
        .HasForeignKey(p => p.PersonaIdFk);
    }
}