namespace Dominio.Entities;
public class RecetaMedica : BaseEntity
{
    public int DoctorIdFk { get; set; }
    public Persona Doctor { get; set; }
    public int PacienteIdFk { get; set; }
    public Persona Paciente { get; set; }
    public DateTime FechaCaducidad { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string Descripcion { get; set; }
}
