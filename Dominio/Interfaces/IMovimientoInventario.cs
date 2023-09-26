using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMovimientoInventario: IGenericRepo<MovimientoInventario>
{
    Task<double> TotalDineroVentasMedicamentos();
}
