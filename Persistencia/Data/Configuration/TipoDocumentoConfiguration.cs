using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
            {
                public void Configure(EntityTypeBuilder<TipoDocumento> builder)
                {
                    builder.ToTable("tipoDocumento");
        
                    builder.HasKey(e => e.Id);
    
                    builder.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();
                }
            }
    
}