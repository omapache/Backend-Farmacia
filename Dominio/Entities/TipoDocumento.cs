namespace Dominio.Entities;
public class TipoDocumento : BaseEntity
{
    public string descripcion { get; set; }
    public ICollection<Persona> Persona { get; set; }
}