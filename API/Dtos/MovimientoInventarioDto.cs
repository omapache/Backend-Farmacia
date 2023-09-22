namespace API.Dtos;
public class MovimientoInventarioDto
{
    public int Id { get; set; }
    public DateOnly FechaMovimiento { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public FormaPagoDto FormaPago{ get; set; }
    public TipoMovimientoInventarioDto TipoMovimientoInventario { get; set; }
    public PersonaDto Receptor { get; set; }
    public PersonaDto Responsable { get; set; }
    public RecetaMedicaDto RecetaMedica { get; set; }
}
