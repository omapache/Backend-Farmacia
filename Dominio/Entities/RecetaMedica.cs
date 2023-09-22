namespace Dominio.Entities;
public class RecetaMedica : BaseEntity
{
    public int DoctorIdFk { get; set; }
    public Persona Doctor { get; set; }
    public int PacienteIdFk { get; set; }
    public Persona Paciente { get; set; }
    public DateOnly FechaCaducidad { get; set; }
    public DateOnly FechaCreacion { get; set; }
    public string Descripcion { get; set; }
    public virtual MovimientoInventario MovimientoInventario { get; set; }
    
}
