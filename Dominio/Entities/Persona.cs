namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public int TipoPersonaIdFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int TipoDocumentoIdFk { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }
    public int RolIdFk { get; set; }
    public Rol Rol { get; set; }
    public ICollection<Producto> Productos { get; set; } = new HashSet<Producto>();
    public ICollection<Direccion> Direcciones { get; set; }
    public ICollection<Telefono> Telefonos { get; set; }
    public ICollection<Email> Emails { get; set; }
    public ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; }
    public ICollection<ProductoProveedor> ProductoProveedores { get; set; }
    
    public ICollection<MovimientoInventario> MovimientoInventariosResponsable { get; set; }
    public ICollection<MovimientoInventario> MovimientoInventariosReceptor { get; set; }

    public ICollection<RecetaMedica> RecetaMedicaDoctor { get; set; }
    public ICollection<RecetaMedica> RecetaMedicaPaciente { get; set; }

    public virtual User User{ get; set; }

}