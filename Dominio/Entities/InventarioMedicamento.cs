namespace Dominio.Entities;
public class InventarioMedicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public DateOnly FechaExpiracion { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
    public int TipoPresentacionIdFk { get; set; }
    public TipoPresentacion TipoPresentacion { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    public ICollection<MedicamentoReceta> MedicamentoRecetas { get; set; }
    public ICollection<Producto> Productos { get; set; }
}