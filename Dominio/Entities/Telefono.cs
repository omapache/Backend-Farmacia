namespace Dominio.Entities;

public class Telefono : BaseEntity
{
    public string Numero { get; set; }
    public int TipoTelefonoIdFk { get; set; }
    public TipoTelefono TipoTelefono { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
}