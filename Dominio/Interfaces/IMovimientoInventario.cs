using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMovimientoInventario: IGenericRepo<MovimientoInventario>
{
    public  Task<IEnumerable<Object>> TotalVentasxProveedor();
    public  Task<IEnumerable<Object>> ProvSinVentasUltAño();
    public  Task<Object> PacienteMasDineroXAño(int year);
    public  Task<object> PacienteCompMedxAnio(int year , string medicamento);
    public Task<IEnumerable<object>> TotalProvSuministraMedicamentosxAnio(int year);
    public  Task<object> MedicVendXMesYAnio(int year);
    public  Task<IEnumerable<object>> EmpleadoSinVentasMesYAnio(int year, int mes);
}
