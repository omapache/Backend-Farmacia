using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPersona : IGenericRepo<Persona>
{
    public  Task<IEnumerable<Object>> TotalVentasxProveedor();
}
