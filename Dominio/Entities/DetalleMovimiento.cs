

namespace Dominio.Entities;

public class DetalleMovimiento : BaseEntity
{
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public int InventMedicamentoIdFk { get; set; }
    public InventarioMedicamento InventarioMedicamento { get; set; }
    public int MovInventarioIdFk { get; set; }
    public MovimientoInventario MovimientoInventario { get; set; }

}
