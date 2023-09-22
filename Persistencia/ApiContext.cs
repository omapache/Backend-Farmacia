using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    { }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<FormaPago> FormaPagos { get; set; }
    public DbSet<InventarioMedicamento> InventarioMedicamentos { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<MedicamentoReceta> MedicamentoRecetas { get; set; }
    public DbSet<MovimientoInventario> MovimientoInventarios { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<ProductoProveedor> ProductoProveedores { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RecetaMedica> RecetaMedicas { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Telefono> Telefonos { get; set; }
    public DbSet<TipoDocumento> TipoDocumentos { get; set; }
    public DbSet<TipoEmail> TiposEmails { get; set; }
    public DbSet<TipoMovimientoInventario> TipoMovimientoInventarios { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }
    public DbSet<TipoPresentacion> TipoPresentaciones { get; set; }
    public DbSet<TipoTelefono> TiposTelefonos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRol> UsersRols { get; set; }
    public DbSet<MovimientoInventario> MovimientoInventariosResponsable { get; set; }
    public DbSet<MovimientoInventario> MovimientoInventariosReceptor { get; set; }
    public DbSet<RecetaMedica> RecetaMedicaDoctor { get; set; }
    public DbSet<RecetaMedica> RecetaMedicaPaciente { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
