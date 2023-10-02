using Dominio.Entities;

namespace API.Dtos;

public class DepartamentoDto
{
    public int Id { get; set; }
    public string NombreDepartamento { get; set; }
    public int PaisIdFk { get; set; }
/*     public PaisDto Pais { get; set; }
 */
 }