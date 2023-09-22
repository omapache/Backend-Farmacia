namespace API.Dtos;

public class DireccionDto
{
    public int Id { get; set; }
    public string CallePrincipal { get; set; }
    public string CalleSecundaria { get; set; }
    public string Numero { get; set; }
    public string Descripcion { get; set; }
    public CiudadDto Ciudad { get; set; }
    public PersonaDto Persona{ get; set; }
}