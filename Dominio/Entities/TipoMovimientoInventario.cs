

namespace Dominio.Entities;
public class TipoMovimientoInventario : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
}
