namespace Dominio.Entities;

public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }
    public int DepartamentoIdFk { get; set; }
    public Departamento Departamento { get; set; }
    public ICollection<Direccion> Direcciones { get; set; }
}