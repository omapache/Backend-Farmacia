using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    {}
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<RecetaMedica> RecetasMedicas { get; set; }
    public DbSet<Telefono> Telefonos { get; set; }
    public DbSet<TipoEmail> TiposEmails { get; set; }
    public DbSet<TipoTelefono> TiposTelefonos { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MedicamentoComprado> MedicamentoComprados { get; set; }
    public DbSet<MedicamentoVendido> MedicamentoVendidos { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<RecetaMedica> RecetaMedicas { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRol> UsersRols { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
