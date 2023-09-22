namespace Dominio.Entities;
public class TipoPresentacion : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<DescripcionMedicamento> DescripcionMedicamentos  { get; set; }
}
