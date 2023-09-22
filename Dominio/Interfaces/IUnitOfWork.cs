namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    ICiudad Ciudades { get; }
    IDepartamento Departamentos { get; }
    IDetalleMovimiento DetalleMovimientos { get; }
    IDireccion Direcciones { get; }
    IEmail Emails { get; }
    IFormaPago FormaPagos { get; }
    IInventarioMedicamento InventarioMedicamentos { get; }
    IMarca Marcas { get; }
    IMedicamentoReceta MedicamentoRecetas { get; }
    IMovimientoInventario MovimientoInventarios { get; }
    IPais Paises { get; }
    IPersona Personas { get; }
    IProducto Productos { get; }
    IRecetaMedica RecetaMedicas { get; }
    IRol Rols { get; }
    ITelefono Telefonos { get; }
    ITipoDocumento TipoDocumentos { get; }
    ITipoEmail TipoEmails { get; }
    ITipoMovimientoInventario TipoMovimientoInventarios { get; }
    ITipoPersona TipoPersonas { get; }
    IDescripcionMedicamento DescripcionMedicamentos { get; }
    ITipoTelefono TipoTelefonos { get; }
    IUser Users { get; }
    Task<int> SaveAsync();
}