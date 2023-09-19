namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public string Direccion { get; set; }
    public int TipoPersonaIdFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
}