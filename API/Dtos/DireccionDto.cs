namespace API.Dtos;

public class DireccionDto
{
    public int Id { get; set; }
    public string CallePrincipal { get; set; }
    public string CalleSecundaria { get; set; }
    public string Numero { get; set; }
    public string Descripcion { get; set; }
    public int CiudadIdFk { get; set; }
    public int PersonaIdFk { get; set; }
}