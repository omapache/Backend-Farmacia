using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(p => p.Username)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();


            builder.Property(p => p.Password)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder
           .HasMany(p => p.Rols)
           .WithMany(r => r.Users)
           .UsingEntity<UserRol>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.UsersRols)
               .HasForeignKey(ut => ut.RolIdFk),


               j => j
               .HasOne(et => et.User)
               .WithMany(et => et.UsersRols)
               .HasForeignKey(el => el.UsuarioIdFk),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.UsuarioIdFk, t.RolIdFk });

               });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        }

    }
}
