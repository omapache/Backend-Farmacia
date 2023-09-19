namespace Dominio.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
}