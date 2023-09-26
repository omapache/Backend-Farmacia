using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPersona : IGenericRepo<Persona>
{
    Task<IEnumerable<object>> EmpleadosConMasDe5Ventas();
    Task<IEnumerable<object>> EmpleadosSinVentas(int year);
    Task<IEnumerable<object>> ProveedoresMedicamentosStockBajo();
    Task<object> EmpleadoMaxMedicamentosDistintos(int year);
    Task<IEnumerable<object>> ProveedoresMedicamentosDiferentes(int year);
}
