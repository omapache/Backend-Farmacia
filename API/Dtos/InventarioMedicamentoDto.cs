namespace API.Dtos;
public class InventarioMedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public DateOnly FechaExpiracion { get; set; }
    public PersonaDto Persona { get; set; }
    public DescripcionMedicamentoDto DescripcionMedicamento { get; set; }
    /*     public int PersonaIdFk { get; set; }
        public int TipoPresentacionIdFk { get; set; } */
}
