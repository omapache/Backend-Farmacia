using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RecetaMedicaConfiguration : IEntityTypeConfiguration<RecetaMedica>
            {
                public void Configure(EntityTypeBuilder<RecetaMedica> builder)
                {
                    builder.ToTable("recetaMedica");
        
                    builder.HasKey(e => e.Id);
    
                    builder.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar")
                    .HasMaxLength(256)
                    .IsRequired();

                    builder.Property(e => e.FechaCaducidad)
                    .HasColumnName("fechaCadudicad")
                    .HasColumnType("DateTime")
                    .HasMaxLength(30)
                    .IsRequired();
                    builder.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("DateTime")
                    .HasMaxLength(30)
                    .IsRequired();

                    builder.HasOne(p => p.Paciente)
                    .WithMany(p => p.RecetaMedicas)
                    .HasForeignKey(p => p.PacienteIdFk);

                    builder.HasOne(p => p.Doctor)
                    .WithMany(p => p.RecetaMedicas)
                    .HasForeignKey(p => p.DoctorIdFk);
                }
            }
    
}