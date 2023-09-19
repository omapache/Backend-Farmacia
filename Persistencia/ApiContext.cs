using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    {}
    public DbSet<Compra> Compras { get; set; }
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
