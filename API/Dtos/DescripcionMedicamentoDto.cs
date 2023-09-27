
namespace API.Dtos;

public class DescripcionMedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CantidadMg { get; set; }
    public string Descripcion { get; set; }
    public int TipoPresentacionIdFk { get; set; }
    public TipoPresentacionDto TipoPresentacion { get; set; } 
}
