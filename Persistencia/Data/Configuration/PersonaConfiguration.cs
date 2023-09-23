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

        builder.Property(e => e.NumeroDocumento)
        .HasColumnName("numeroDocumento")
        .HasColumnType("varchar")
        .HasMaxLength(150)
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

/*         builder
        .HasMany(p => p.Productos)
        .WithMany(p => p.Personas)
        .UsingEntity<ProductoProveedor>(
          j => j
            .HasOne(pt => pt.Producto)
            .WithMany(t => t.ProductoProveedores)
            .HasForeignKey(pt => pt.ProductoIdFk),
          j => j
            .HasOne(pt => pt.Proveedor)
            .WithMany(t => t.ProductoProveedores)
            .HasForeignKey(pt => pt.ProveedorIdFk),
          j => 
            {
              j.HasKey(t => new {t.ProveedorIdFk, t.ProductoIdFk});
            }); */

        builder.HasOne(e => e.User)
        .WithOne(p => p.Persona)
        .HasForeignKey<User>(p => p.PersonaIdFk);
    }
}
