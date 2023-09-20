namespace Dominio.Entities;
public class TipoDocumento : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Persona> Personas { get; set; }
}