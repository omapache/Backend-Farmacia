namespace API.Dtos;

public class TelefonoDto
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public int TipoTelefonoIdFk { get; set; }
    public int PersonaIdFk { get; set; }
}