
namespace API.Dtos;

public class DescripcionMedicamentoDto
{
    public string Nombre { get; set; }
    public string CantidadMg { get; set; }
    public string Descripcion { get; set; }
    public TipoPresentacionDto TipoPresentacion { get; set; } 
}
