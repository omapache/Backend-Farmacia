using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly ApiContext _context;
    
    public PersonaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
        .Include(p => p.TipoDocumento)
        .Include(p => p.TipoPersona)
        .Include(p => p.Rol)


            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .Include(p => p.TipoDocumento)
        .Include(p => p.TipoPersona)
        .Include(p => p.Rol)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<string>> ObtenerEmpleadosConMenosDe5VentasAsync(int año)
{
    var empleadosConMenosDe5Ventas = await (
        from mi in _context.MovimientoInventarios
        join e in _context.Personas on mi.ResponsableIdFk equals e.Id
        where mi.FechaMovimiento.Year == año
        where mi.TipoMovInventIdFk == 2
        group mi by new { e.Nombre, e.Id } into grupoVentas
        where grupoVentas.Count() < 5
        select grupoVentas.Key.Nombre
    ).ToListAsync();

    if (empleadosConMenosDe5Ventas.Any())
    {
        return empleadosConMenosDe5Ventas;
    }
    else
    {
        return new List<string> { "No se encontraron empleados con menos de 5 ventas en " + año };
    }
}
    public async Task<IEnumerable<string>> ObtenerPacientesSinComprasEn2023Async()
    {
        var pacientesConComprasEn2023 = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            where d.TipoMovInventIdFk == 1
            where d.FechaMovimiento.Year == 2023
            select p.Nombre
        ).ToListAsync();

        var todosLosPacientes = await (
            from p in _context.Personas
            where p.RolIdFk == 4
            select p.Nombre
        ).ToListAsync();

        var pacientesSinComprasEn2023 = todosLosPacientes.Except(pacientesConComprasEn2023);

        if (pacientesSinComprasEn2023.Any())
        {
            return pacientesSinComprasEn2023;
        }
        else
        {
            return new List<string> { "Todos los pacientes han realizado compras en 2023" };
        }
    }
    public async Task<IEnumerable<KeyValuePair<string, double>>> CalcularTotalGastadoPorPacienteEn2023Async()
    {
        var totalGastadoPorPaciente = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            where d.TipoMovInventIdFk == 1
            where p.RolIdFk == 4
            where d.FechaMovimiento.Year == 2023
            group dm by p.Nombre into grupoCompras
            select new KeyValuePair<string,double>(
                grupoCompras.Key,
                grupoCompras.Sum(dm => dm.Precio)
            )
        ).ToListAsync();

        return totalGastadoPorPaciente;
    }
    public async Task<int> CalcularTotalMedicamentosVendidosPrimerTrimestre2023Async()
{
    DateOnly fechaInicioPrimerTrimestre = new DateOnly(2023, 1, 1);

    DateOnly fechaFinPrimerTrimestre = new DateOnly(2023, 3, 31);

    var totalMedicamentosVendidos = await (
        from mi in _context.MovimientoInventarios
        where mi.TipoMovInventIdFk == 1
        where mi.FechaMovimiento >= fechaInicioPrimerTrimestre && mi.FechaMovimiento <= fechaFinPrimerTrimestre
        select mi
    ).CountAsync();

    return totalMedicamentosVendidos;
}
}


