using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
        .HasMaxLength(3);

        builder.Property(e => e.Precio)
        .HasColumnName("precio")
        .HasColumnType("double")
        .IsRequired();

        builder.Property(e => e.Cantidad)
        .HasColumnName("cantidad")
        .HasColumnType("int")
        .HasMaxLength(3)
        .IsRequired();


        builder.HasOne(p => p.InventarioMedicamento)
        .WithMany(p => p.Productos)
        .HasForeignKey(p => p.InventMedicamentoIdFk);

        builder.HasOne(p => p.Marca)
        .WithMany(p => p.Productos)
        .HasForeignKey(p => p.MarcaIdFk);
         
    }
}
