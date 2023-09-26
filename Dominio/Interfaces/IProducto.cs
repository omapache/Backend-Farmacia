using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IProducto : IGenericRepo<Producto>
{
    Task<IEnumerable<object>> InformacionContacto();
    Task<IEnumerable<Object>> NumeroMedicamentosPorProveedor();
    Task<int> TotalMedicamentosVendidosMarzo();
    Task<IEnumerable<object>> PromedioMedicamentosPorVenta();
    Task<int> TotalMedicamentosVendidosPorMes(int year, int mes);
}
