namespace API.Dtos;

public class CiudadDto
{
    public int Id { get; set; }
    public string NombreCiudad { get; set; }
    public DepartamentoDto Departamento { get; set; }
}