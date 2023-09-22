using System.Security.Cryptography.X509Certificates;

namespace Dominio.Entities;
public class DescripcionMedicamento : BaseEntity
{
    public string Nombre { get; set; }
    public string CantidadMg { get; set; }
    public string Descripcion { get; set; }
    public int TipoPresentacionIdFk { get; set; }
    public TipoPresentacion TipoPresentacion { get; set; } 
    public ICollection<InventarioMedicamento> InventarioMedicamentos { get; set; }
}
