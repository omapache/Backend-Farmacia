namespace Dominio.Entities;
public class Compra : BaseEntity
{
    public DateTime FechaCompra { get; set; }
    public int ProveedorIdFk { get; set; }
    public Persona Proveedor { get; set; }
    public ICollection<MedicamentoComprado> MedicamentoComprados { get; set; }
}
