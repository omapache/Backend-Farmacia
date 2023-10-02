namespace API.Dtos
{
public class RecetaMedicaDto
{
    public int Id { get; set;}
    public int DoctorIdFk { get; set; }
    public int PacienteIdFk { get; set; }
    public PersonaDto Doctor { get; set; }
    public PersonaDto Paciente { get; set; }
    public DateOnly FechaCaducidad { get; set; }
    public DateOnly FechaCreacion { get; set; }
    public string Descripcion { get; set; }
}
}