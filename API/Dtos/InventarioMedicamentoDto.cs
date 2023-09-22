namespace API.Dtos;
public class InventarioMedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public DateOnly FechaExpiracion { get; set; }
    public PersonaDto Persona { get; set; }
<<<<<<< HEAD
    public TipoPresentacionDto TipoPresentacion { get; set; }
=======
    public DescripcionMedicamentoDto DescripcionMedicamento { get; set; }
    /*     public int PersonaIdFk { get; set; }
        public int TipoPresentacionIdFk { get; set; } */
>>>>>>> 5f9237c69e4978051a897567b843401880b85e43
}
