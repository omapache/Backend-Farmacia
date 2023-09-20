namespace Dominio.Entities;

public class MovimientoInventario : BaseEntity
{
    public DateOnly FechaMovimiento { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public int FormaPagoIdFk { get; set; }
    public FormaPago FormaPago { get; set; }
    public int TipoMovimientoIdFk { get; set; }
    public TipoMovimientoInventario TipoMovimientoInventario { get; set; }
    public int ResponsableIdFk { get; set; }
    public Persona Responsable { get; set; }
    public int ReceptorIdFk { get; set; }
    public Persona Receptor { get; set; }
    public int RecetaMedicaIdFk { get; set; }
    public RecetaMedica RecetaMedica { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}
