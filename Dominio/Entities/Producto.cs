namespace Dominio.Entities;
public class Producto : BaseEntity
{
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public int InventMedicamentoIdFk { get; set; }
    public InventarioMedicamento InventarioMedicamento { get; set; }
    public int MarcaIdFk { get; set; }
    public Marca Marca { get; set; }
    public ICollection<ProductoProveedor> ProductoProveedores { get; set; }
    public ICollection<Persona> Personas { get; set; } = new HashSet<Persona>();
}
