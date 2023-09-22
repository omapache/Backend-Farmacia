namespace API.Dtos;
public class ProductoDto
{
    public int Id { get; set;}
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public InventarioMedicamentoDto inventarioMedicamentoDto { get; set; }
    public MarcaDto Marca{ get; set; }
}
