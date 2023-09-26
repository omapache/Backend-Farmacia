using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IInventarioMedicamento  : IGenericRepo<InventarioMedicamento>
{
    Task<IEnumerable<InventarioMedicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad);
    Task<IEnumerable<object>> ObtenerMedicamentosCaducadosAsync(DateOnly fechaLimite);
    Task<IEnumerable<object>> ObtenerMedicamentosSinVentaAsync();
    Task<IEnumerable<object>> ObtenerMedicamentosVendidoEspecificoAsync(string Nombre);
    Task<IEnumerable<Object>> ObtenerPacienteCompradoEspecificoAsync(string medicina);
    Task<object> ObtenerMedicamentoMenosVendidoAsync(int Año);
    Task<IEnumerable<object>> ObtenerMedicamentosSinVentaNuncaAsync();

    
}
