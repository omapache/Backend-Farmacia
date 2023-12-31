using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly ApiContext _context;

    public PersonaRepository(ApiContext context) : base(context)
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
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<object>> EmpleadosConMasDe5Ventas()
    {
        return await (
            from d in _context.MovimientoInventarios
            join p in _context.Personas on d.ResponsableIdFk equals p.Id 
            where d.TipoMovInventIdFk == 1 && p.RolIdFk == 2 
            group d by new { p.Id, p.Nombre } into grupoVentas
            where grupoVentas.Count() > 5
            select new
            {
                EmpleadoId = grupoVentas.Key.Id,
                Nombre = grupoVentas.Key.Nombre,
                NumeroVentas = grupoVentas.Count()
            }
        ).ToListAsync();
    }

    public async Task<IEnumerable<object>> EmpleadosSinVentas()
    {
        return await (
            from d in _context.MovimientoInventarios
            join p in _context.Personas on d.ResponsableIdFk equals p.Id 
            where d.TipoMovInventIdFk == 1 && p.RolIdFk == 2 
            group d by new { p.Id, p.Nombre } into grupoVentas
            where grupoVentas.Count() == 0
            select new
            {
                EmpleadoId = grupoVentas.Key.Id,
                Nombre = grupoVentas.Key.Nombre,
                NumeroVentas = grupoVentas.Count()
            }
        ).ToListAsync();
    }

    public async Task<IEnumerable<object>> EmpleadosSinVentas(int year)
    {
        var inicioAño = new DateOnly(year, 1, 1);
        var finAño = new DateOnly(year, 12, 31);

        var empleadosConVentas = await (
            from d in _context.MovimientoInventarios
            join p in _context.Personas on d.ResponsableIdFk equals p.Id
            where d.TipoMovInventIdFk == 1 && d.FechaMovimiento >= inicioAño && d.FechaMovimiento <= finAño
            select p.Id
        ).Distinct().ToListAsync();

        var empleadosSinVentas = await (
            from p in _context.Personas
            where !empleadosConVentas.Contains(p.Id) && p.RolIdFk == 2
            select new
            {
                EmpleadoId = p.Id,
                Nombre = p.Nombre,
                NumeroVentas = 0
            }
        ).ToListAsync();

        return empleadosSinVentas;
    }

    public async Task<IEnumerable<object>> ProveedoresMedicamentosStockBajo()
    {
        return await (
            from im in _context.InventarioMedicamentos
            join p in _context.Personas on im.PersonaIdFk equals p.Id
            where p.RolIdFk == 3 
            where im.Stock < 50
            select new
            {
                ProveedorId = p.Id,
                NombreProveedor = p.Nombre
            }
        ).Distinct().ToListAsync();
    }

public async Task<object> EmpleadoMaxMedicamentosDistintos(int year)
{
    var inicioAño = new DateOnly(year, 1, 1);
    var finAño = new DateOnly(year, 12, 31);

    var resultados = await (
        from d in _context.MovimientoInventarios
        join dm in _context.DetalleMovimientos on d.Id equals dm.MovInventarioIdFk
        join p in _context.Personas on d.ReceptorIdFk equals p.Id
        where d.TipoMovInventIdFk == 1 && d.FechaMovimiento >= inicioAño && d.FechaMovimiento <= finAño
        where p.RolIdFk == 2
        group dm by new { p.Id, d.ResponsableIdFk } into grupoVentas
        select new
        {
            EmpleadoId = grupoVentas.Key.ResponsableIdFk,
            MedicamentosDistintos = grupoVentas.Select(x => x.InventMedicamentoIdFk).Distinct().Count()
        }
    ).OrderByDescending(x => x.MedicamentosDistintos).FirstOrDefaultAsync();

    return resultados;
}





    public async Task<IEnumerable<object>> ProveedoresMedicamentosDiferentes(int year)
    {
        var inicioa = new DateOnly(year, 1, 1);
        var fina = new DateOnly(year, 12, 31);

        return await (
            from im in _context.InventarioMedicamentos
            join d in _context.MovimientoInventarios on im.Id equals d.TipoMovInventIdFk
            join p in _context.Personas on im.PersonaIdFk equals p.Id
            where p.RolIdFk == 3 && d.FechaMovimiento >= inicioa && d.FechaMovimiento <= fina
            group im by new { im.PersonaIdFk, p.Nombre } into grupoProveedor
            where grupoProveedor.Select(x => x.DescripcionMedicamentoIdFk).Distinct().Count() >= 5
            select new
            {
                ProveedorId = grupoProveedor.Key.PersonaIdFk,
                NombreProveedor = grupoProveedor.Key.Nombre,
                MedicamentosDiferentes = grupoProveedor.Select(x => x.DescripcionMedicamentoIdFk).Distinct().Count()
            }
        ).ToListAsync();
    }
    public async Task<IEnumerable<string>> ObtenerEmpleadosConMenosDe5VentasAsync(int año)
{
    var empleadosConMenosDe5Ventas = await (
        from mi in _context.MovimientoInventarios
        join e in _context.Personas on mi.ResponsableIdFk equals e.Id
        where mi.FechaMovimiento.Year == año
        where e.RolIdFk == 2
        where mi.TipoMovInventIdFk == 1
        group mi by new { e.Nombre, e.Id } into grupoVentas
        where grupoVentas.Count() < 5 && grupoVentas.Count() == 0
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
            where p.RolIdFk == 5
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
    public async Task<IEnumerable<object>> PacientesConTotalGastadoPorAño()
{
    var pacientesConTotalGastado = await (
        from m in _context.MovimientoInventarios
        join persona in _context.Personas on m.ReceptorIdFk equals persona.Id
        join detalle in _context.DetalleMovimientos on m.Id equals detalle.MovInventarioIdFk
        where m.TipoMovInventIdFk == 2
        where persona.RolIdFk == 5
        where m.FechaMovimiento.Year == 2023 // Filtra por el año 2023
        group new { detalle.Precio, detalle.Cantidad } by persona into g
        select new
        {
            Paciente = g.Key.Nombre,
            TotalGastado = g.Sum(x => x.Precio * x.Cantidad)
        }).ToListAsync();

    return pacientesConTotalGastado;
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
     public async Task<IEnumerable<Object>> GananciaTotalPorProveedorEn2023()
    {
        var year = 2023; // Año para el que deseas calcular la ganancia

        return await (
            from mi in _context.MovimientoInventarios
            join d in _context.DetalleMovimientos on mi.Id equals d.MovInventarioIdFk
            join per in _context.Personas on  mi.ResponsableIdFk equals  per.Id
            join im in _context.InventarioMedicamentos on d.InventMedicamentoIdFk equals im.Id
            join prod in _context.Productos on im.Id equals prod.InventMedicamentoIdFk
            join dm in _context.DescripcionMedicamentos on im.DescripcionMedicamentoIdFk equals dm.Id
            where per.RolIdFk == 3
            where mi.TipoMovInventIdFk == 1 && mi.FechaMovimiento.Year == year
            select new
            {
                NombreProveedor = per.Nombre,
                IdProducto = d.Id,
                Producto = dm.Nombre,
                Identificacion = per.NumeroDocumento,
                Ganancia = (d.Precio - prod.Precio) * d.Cantidad // Calcular la ganancia por compra
            }
        ).ToListAsync();
    }

}
