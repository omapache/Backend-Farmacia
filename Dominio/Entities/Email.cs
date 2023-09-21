namespace Dominio.Entities;

public class Email : BaseEntity
{
    public string Direccion { get; set; }
    public int TipoEmailIdFk { get; set; }
    public TipoEmail TipoEmail { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
}