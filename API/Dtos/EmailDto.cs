namespace API.Dtos;

public class EmailDto
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public int TipoEmailIdFk { get; set; }
    public int PersonaIdFk { get; set; }
}