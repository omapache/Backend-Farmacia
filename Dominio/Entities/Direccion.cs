namespace Dominio.Entities;

public class Direccion : BaseEntity
{
    public string CallePrincipal { get; set; }
    public string CalleSecundaria { get; set; }
    public string Numero { get; set; }
    public string Descripcion { get; set; }
    public int CiudadIdFk { get; set; }
    public Ciudad Ciudad { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
    public ICollection<Persona> Personas { get; set; }
}