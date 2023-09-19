namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public string Direccion { get; set; }
    public int TipoPersonaIdFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
    
    public ICollection<Compra> Compras { get; set; }
    public ICollection<Medicamento> Medicamentos { get; set; }
    public ICollection<Venta> Ventas { get; set; }
    public ICollection<RecetaMedica> RecetaMedicas { get; set; }
    public ICollection<TipoPersona> TipoPersonas { get; set; }

}