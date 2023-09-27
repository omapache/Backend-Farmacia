using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IDetalleMovimiento : IGenericRepo<DetalleMovimiento>
{
    Task<string> ObtenerProveedorMasSuministrosAsync(int año);
}
