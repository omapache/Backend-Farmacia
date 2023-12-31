using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MedicamentoRecetaConfiguration : IEntityTypeConfiguration<MedicamentoReceta>
    {
        public void Configure(EntityTypeBuilder<MedicamentoReceta> builder)
        {
            builder.ToTable("medicamentoReceta");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasColumnType("varchar")
            .HasMaxLength(256)
            .IsRequired();

            builder.HasOne(p => p.RecetaMedica)
            .WithMany(p => p.MedicamentoRecetas)
            .HasForeignKey(p => p.RecetaIdFk);

             builder.HasOne(p => p.InventarioMedicamento)
            .WithMany(p => p.MedicamentoRecetas)
            .HasForeignKey(p => p.IventMedicamentoIdFk);
        }
    }

}