using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPersona : IGenericRepo<Persona>
{
    Task<IEnumerable<string>> ObtenerEmpleadosConMenosDe5VentasAsync(int año);
    Task<IEnumerable<string>> ObtenerPacientesSinComprasEn2023Async();
    Task<IEnumerable<KeyValuePair<string, double>>> CalcularTotalGastadoPorPacienteEn2023Async();
    Task<int> CalcularTotalMedicamentosVendidosPrimerTrimestre2023Async();
    Task<IEnumerable<object>> EmpleadosConMasDe5Ventas();
    Task<IEnumerable<object>> EmpleadosSinVentas(int year);
    Task<IEnumerable<object>> ProveedoresMedicamentosStockBajo();
    Task<IEnumerable<object>> EmpleadoMaxMedicamentosDistintos(int year);
    Task<IEnumerable<object>> ProveedoresMedicamentosDiferentes(int year);
    
}
