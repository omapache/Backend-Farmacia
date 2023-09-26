using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IInventarioMedicamento  : IGenericRepo<InventarioMedicamento>
{
    Task<IEnumerable<InventarioMedicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad);
    Task<IEnumerable<object>> ObtenerMedicamentosCaducadosAsync(DateOnly fechaLimite);
    Task<IEnumerable<object>> ObtenerMedicamentosSinVentaAñoAsync(int Año);
    Task<IEnumerable<object>> ObtenerMedicamentosVendidoEspecificoAsync(string Nombre);
    Task<IEnumerable<Object>> ObtenerPacienteCompradoEspecificoAsync(string medicina);
    Task<int> TotalVentasMedicamento(string NombreMedicamento);
    Task<IEnumerable<object>> GetMedicamentosEspecificos();
    Task<object> ObtenerMedicamentoMenosVendidoAsync(int Año);
    Task<IEnumerable<object>> ObtenerMedicamentosSinVentaNuncaAsync();

}
