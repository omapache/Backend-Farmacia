using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IRecetaMedica : IGenericRepo<RecetaMedica>
{
    Task<IEnumerable<RecetaMedica>> ObtenerRecetaMedicaGenDesPrimEneroAsync(int year);
}
