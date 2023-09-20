namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public int TipoPersonaIdFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int TipoDocumentoIdFk { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public int RolIdFk { get; set; }
    public Rol Rol { get; set; }
    public ICollection<Producto> Productos { get; set; } = new HashSet<Producto>();
    public ICollection<Direccion> Direcciones { get; set; }
    public ICollection<RecetaMedica> RecetaMedicas { get; set; }
    public ICollection<TipoPersona> TipoPersonas { get; set; }
    public ICollection<Telefono> Telefonos { get; set; }
    public ICollection<Email> Emails { get; set; }
    public ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; }
    public ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    public ICollection<ProductoProveedor> ProductoProveedores { get; set; }
}