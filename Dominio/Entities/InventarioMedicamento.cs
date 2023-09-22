namespace Dominio.Entities;
public class InventarioMedicamento : BaseEntity
{
    public int Stock { get; set; }
    public DateOnly FechaExpiracion { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
    public int DescripcionMedicamentoIdFk { get; set; }
    public DescripcionMedicamento DescripcionMedicamento { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    public ICollection<MedicamentoReceta> MedicamentoRecetas { get; set; }
    public ICollection<Producto> Productos { get; set; }
}