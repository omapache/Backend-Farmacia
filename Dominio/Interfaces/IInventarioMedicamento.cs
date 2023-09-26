using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IInventarioMedicamento  : IGenericRepo<InventarioMedicamento>
{
    Task<IEnumerable<InventarioMedicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad);
    Task<IEnumerable<object>> ObtenerMedicamentosCaducadosAsync(DateOnly fechaLimite);
    Task<IEnumerable<object>> ObtenerMedicamentosSinExpirarAsync();
    Task<IEnumerable<object>> ObtenerMedicamentosVendidoEspecificoAsync(string Nombre);
    Task<IEnumerable<Object>> ObtenerPacienteCompradoEspecificoAsync(string medicina);
    
     Task<IEnumerable<object>> MedExpiranXAñoAsync(int year);
    
    
}
