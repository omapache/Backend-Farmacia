using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMovimientoInventario: IGenericRepo<MovimientoInventario>
{
    public  Task<IEnumerable<Object>> TotalVentasxProveedor();
    public  Task<IEnumerable<Object>> ProvSinVentasUltAño();
}
