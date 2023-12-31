namespace API.Dtos;
public class MovimientoInventarioDto
{
    public int Id { get; set; }
    public DateOnly FechaMovimiento { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public int FormaPagoIdFk { get; set; }
    public FormaPagoDto FormaPago{ get; set; }
    public int TipoMovInventIdFk { get; set; }
    public int ResponsableIdFk { get; set; }
    public int ReceptorIdFk { get; set; }

    public int RecetaMedicaIdFk { get; set; }

    public TipoMovimientoInventarioDto TipoMovimientoInventario { get; set; }
    public PersonaDto Receptor { get; set; }
    public PersonaDto Responsable { get; set; }
    public RecetaMedicaDto RecetaMedica { get; set; }
}
