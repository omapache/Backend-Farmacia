namespace Dominio.Entities;
public class ProductoProveedor
{
    public int ProductoIdFk { get; set; }
    public Producto Producto {get;set;}
    public int ProveedorIdFk { get; set; }
    public Persona Proveedor { get; set; }
}
