using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IProducto : IGenericRepo<Producto>
{
    Task<IEnumerable<object>> InformacionContacto();

}
