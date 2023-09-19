namespace Dominio.Entities;
    public class Venta : BaseEntity
{
    public DateTime FechaVenta { get; set; }
    public int PacienteIdFk { get; set; }
    public Persona Paciente { get; set; }
    public int EmpleadoIdFk { get; set; }
    public Persona Empleado { get; set; }
}
