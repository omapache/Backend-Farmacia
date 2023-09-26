using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IProducto : IGenericRepo<Producto>
{
    Task<IEnumerable<object>> InformacionContacto();
    Task<IEnumerable<Object>> NumeroMedicamentosPorProveedor();
    Task<int> TotalMedicamentosVendidosMarzo();
}
