namespace Dominio.Entities;
public class TipoPresentacion : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; }
}
