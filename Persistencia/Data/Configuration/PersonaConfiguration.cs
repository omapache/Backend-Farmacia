using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
        {
            public void Configure(EntityTypeBuilder<Persona> builder)
            {
                builder.ToTable("persona");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

                builder.HasOne(p => p.TipoDocumento)
                .WithMany(p => p.Personas)
                .HasForeignKey(p => p.TipoDocumentoIdFk);

                builder.HasOne(p => p.TipoPersona)
                .WithMany(p => p.Personas)
                .HasForeignKey(p => p.TipoPersonaIdFk);

                builder.HasOne(p => p.Rol)
                .WithMany(p => p.Personas)
                .HasForeignKey(p => p.RolIdFk);
            }
        }
