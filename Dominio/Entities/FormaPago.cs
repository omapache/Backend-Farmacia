namespace Dominio.Entities;
public class FormaPago : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
}
