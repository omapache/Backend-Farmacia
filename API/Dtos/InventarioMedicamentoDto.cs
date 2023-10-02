namespace API.Dtos;
public class InventarioMedicamentoDto
{
    public int Id { get; set; }
    public int Stock { get; set; }
    public DateOnly FechaExpiracion { get; set; }
    public int PersonaIdFk { get; set; }
    public PersonaDto Persona { get; set; }
    public int DescripcionMedicamentoIdFk { get; set; }
    public DescripcionMedicamentoDto DescripcionMedicamento { get; set; }

}
