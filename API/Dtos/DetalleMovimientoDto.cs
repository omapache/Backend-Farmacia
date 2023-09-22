namespace API.Dtos;
public class DetalleMovimientoDto
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public int InventMedicamentoIdFk { get; set; }
    public int MovInventarioIdFk { get; set; }
}
