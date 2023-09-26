using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMovimientoInventario: IGenericRepo<MovimientoInventario>
{
    Task<IEnumerable<object>> ObtenerVentasPorEmpleadoEn2023Async(int Año);
    Task<double> TotalDineroVentasMedicamentos();
}
