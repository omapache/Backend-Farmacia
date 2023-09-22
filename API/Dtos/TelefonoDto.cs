namespace API.Dtos;

public class TelefonoDto
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public TipoTelefonoDto TipoTelefono { get; set; }
    public int PersonaIdFk { get; set; }
}