namespace Dominio.Entities;
public class MedicamentoReceta : BaseEntity
{
    public int RecetaIdFk { get; set; }
    public RecetaMedica RecetaMedica { get; set; }
    public int IventMedicamentoIdFk { get; set; }
    public InventarioMedicamento InventarioMedicamento { get; set; }
    public string Descripcion { get; set; }
}
