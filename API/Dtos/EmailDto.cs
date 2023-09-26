namespace API.Dtos;

public class EmailDto
{
    public int Id { get; set; }
    public string Direccion { get; set; }
    public int TipoEmailIdFk { get; set; }
    public TipoEmailDto TipoEmail { get; set; }
    public PersonaDto Persona { get; set; }
}