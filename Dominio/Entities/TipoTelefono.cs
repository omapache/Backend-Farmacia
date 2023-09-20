namespace Dominio.Entities;

public class TipoTelefono : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Telefono> Telefonos { get; set; }
}