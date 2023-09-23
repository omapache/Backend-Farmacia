using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProductoProveedorConfigurationusing : IEntityTypeConfiguration<ProductoProveedor>
{
    public void Configure(EntityTypeBuilder<ProductoProveedor> builder)
    {
        builder.ToTable("productoProveedor");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.HasOne(p => p.Producto)
        .WithMany(p => p.ProductoProveedores)
        .HasForeignKey(p => p.ProductoIdFk);

        builder.HasOne(p => p.Proveedor)
        .WithMany(p => p.ProductoProveedores)
        .HasForeignKey(p => p.ProveedorIdFk);
         
    }
}
