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
            .HasColumnType("date")
            .IsRequired();
            builder.Property(e => e.FechaCreacion)
            .HasColumnName("fechaCreacion")
            .HasColumnType("date")
            .IsRequired();

            builder.HasOne(p => p.Paciente)
            .WithMany(p => p.RecetaMedicaPaciente)
            .HasForeignKey(p => p.PacienteIdFk);

            builder.HasOne(p => p.Doctor)
            .WithMany(p => p.RecetaMedicaDoctor)
            .HasForeignKey(p => p.DoctorIdFk);

            builder.HasOne(p => p.MovimientoInventario)
            .WithOne(j => j.RecetaMedica)
            .HasForeignKey<MovimientoInventario>(j => j.RecetaMedicaIdFk);
        }
    }

}