using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventario
{
    protected readonly ApiContext _context;

    public MovimientoInventarioRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoInventario>> GetAllAsync()
    {
        return await _context.MovimientoInventarios
        .Include(p => p.FormaPago)
        .Include(p => p.TipoMovimientoInventario)
        .Include(p => p.Responsable)
        .Include(p => p.Receptor)
        .Include(p => p.RecetaMedica)
        .ToListAsync();
    }

    public override async Task<MovimientoInventario> GetByIdAsync(int id)
    {
        return await _context.MovimientoInventarios
        .Include(p => p.FormaPago)
        .Include(p => p.TipoMovimientoInventario)
        .Include(p => p.Responsable)
        .Include(p => p.Receptor)
        .Include(p => p.RecetaMedica)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<IEnumerable<object>> ObtenerVentasPorEmpleadoEn2023Async(int Año)
    {
        var ventasPorEmpleado = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            where d.TipoMovInventIdFk == 1 
            where d.FechaMovimiento.Year == Año
            select new
            {
                Empleado = p.Nombre,
                CantidadVentas = 1,  
            }).ToListAsync();

        var ventasPorEmpleadoLista = ventasPorEmpleado
            .GroupBy(x => x.Empleado)
            .Select(g => new
            {
                Empleado = g.Key,
                CantidadVentas = g.Sum(x => x.CantidadVentas),
            })
            .ToList();

        return ventasPorEmpleadoLista;
    }
    



    public async Task<double> TotalDineroVentasMedicamentos()
    {
        DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

        var totalDineroVentas = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            where d.TipoMovInventIdFk == 1 && i.FechaExpiracion < fechaActual
            select dm.Cantidad * dm.Precio
        ).SumAsync();

        return totalDineroVentas;
    }

    public async Task<object> PacienteCompMedxAnio(int year, string medicamento)
    {
        DateOnly fechaInicio = DateOnly.FromDateTime(new DateTime(year, 1, 1));
        DateOnly fechaFin = DateOnly.FromDateTime(new DateTime(year, 12, 31));

        var medicamentosComprados = await (
            from m in _context.MovimientoInventarios
            join persona in _context.Personas on m.ReceptorIdFk equals persona.Id
            join detalle in _context.DetalleMovimientos on m.Id equals detalle.MovInventarioIdFk
            join invent in _context.InventarioMedicamentos on detalle.InventMedicamentoIdFk equals invent.Id
            join descMed in _context.DescripcionMedicamentos on invent.DescripcionMedicamentoIdFk equals descMed.Id
            where m.TipoMovInventIdFk == 1
            where m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin
            where descMed.Nombre.Contains(medicamento)
            select new{
                nombre = persona.Nombre,
                numeroDocumento = persona.NumeroDocumento
            }).Distinct()
            .ToListAsync();

        return medicamentosComprados;
    }

    public async Task<object> PacienteMasDineroXAño(int year)
    {
        DateOnly fechaInicio = DateOnly.FromDateTime(new DateTime(year, 1, 1));
        DateOnly fechaFin = DateOnly.FromDateTime(new DateTime(year, 12, 31));

        var medicamentosComprados = await (
            from m in _context.MovimientoInventarios
            join persona in _context.Personas on m.ReceptorIdFk equals persona.Id
            join detalle in _context.DetalleMovimientos on m.Id equals detalle.MovInventarioIdFk
            where m.TipoMovInventIdFk == 1
            where m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin
            group new { detalle.Precio, detalle.Cantidad } by persona into g
            orderby g.Sum(x => x.Precio * x.Cantidad) descending
            select new
            {
                Paciente = g.Key.Nombre,
                TotalGastado = g.Sum(x => x.Precio * x.Cantidad)
            }).FirstOrDefaultAsync();

        return medicamentosComprados;
    }

    public async Task<object> MedicVendXMesYAnio(int year)
    {
        DateOnly fechaInicio = DateOnly.FromDateTime(new DateTime(year, 1, 1));
        DateOnly fechaFin = DateOnly.FromDateTime(new DateTime(year, 12, 31));

        var medicamentosComprados = await (
            from m in _context.MovimientoInventarios
            join persona in _context.Personas on m.ReceptorIdFk equals persona.Id
            join detalle in _context.DetalleMovimientos on m.Id equals detalle.MovInventarioIdFk
            join invent in _context.InventarioMedicamentos on detalle.InventMedicamentoIdFk equals invent.Id
            join descMed in _context.DescripcionMedicamentos on invent.DescripcionMedicamentoIdFk equals descMed.Id
            where m.TipoMovInventIdFk == 1
            where m.FechaMovimiento >= fechaInicio && m.FechaMovimiento <= fechaFin
            group new { m.FechaMovimiento.Month, detalle.Cantidad, descMed.Nombre } by new { m.FechaMovimiento.Month, descMed.Nombre } into g
            orderby g.Key.Month
            select new
            {
                Mes = g.Key.Month,
                Medicamento = g.Key.Nombre,
                Cantidad = g.Sum(x => x.Cantidad)
            }).ToListAsync();

        return medicamentosComprados;
    }


    public async Task<IEnumerable<object>> ProvSinVentasUltAño()
    {
        DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Today);
        DateOnly fechaHace1Año = fechaActual.AddDays(-365);

        var query = from per in _context.Personas
                    join t in _context.Rols on per.RolIdFk equals t.Id
                    where t.Nombre == "Proveedor"
                    where !(
                        from p in _context.MovimientoInventarios
                        where p.TipoMovInventIdFk == 2
                        where p.FechaMovimiento > fechaHace1Año
                        select p.ResponsableIdFk
                    ).Contains(per.Id)
                    select  new
                    {
                        Proveedor = per.Nombre,
                        Documento = per.NumeroDocumento,
                        Id = per.Id
                    } ;

        return await query.ToListAsync();
    }

    
   /*  public async Task<IEnumerable<object>> EmpleadoSinVentasMesYAnio(int year, int mes)
    {
        DateOnly fechaInicio = DateOnly.FromDateTime(new DateTime(year, mes, 1));
        DateOnly fechaFin = DateOnly.FromDateTime(new DateTime(year, mes, 31));

        var query = from per in _context.Personas
                    join t in _context.Rols on per.RolIdFk equals t.Id
                    where t.Nombre == "Employee"
                    where !(
                        from p in _context.MovimientoInventarios
                        where p.TipoMovInventIdFk == 1
                        where p.FechaMovimiento >= fechaInicio && p.FechaMovimiento <= fechaFin
                        select p.ResponsableIdFk
                    ).Contains(per.Id)
                    select per;

        return await query.ToListAsync();
    } */
    public async Task<IEnumerable<object>> EmpleadoSinVentasMesYAnio(int year, int mes)
{
    if (year < 1 || year > 9999 || mes < 1 || mes > 12)
    {
        // Valores de año o mes no válidos, manejar el error o retornar una lista vacía según tu lógica.
        return new List<object>();
    }

    DateOnly fechaInicio = new DateOnly(year, mes, 1);
    DateOnly fechaFin = new DateOnly(year, mes, DateTime.DaysInMonth(year, mes));

    var query = from per in _context.Personas
                join t in _context.Rols on per.RolIdFk equals t.Id
                where t.Nombre == "Employee"
                where !(
                    from p in _context.MovimientoInventarios
                    where p.TipoMovInventIdFk == 1
                    where p.FechaMovimiento >= fechaInicio && p.FechaMovimiento <= fechaFin
                    select p.ResponsableIdFk
                ).Contains(per.Id)
                select per;

    return await query.ToListAsync();
}


    public async Task<IEnumerable<object>> TotalProvSuministraMedicamentosxAnio(int year)
    {
        DateOnly fechaInicio = DateOnly.FromDateTime(new DateTime(year, 1, 1));
        DateOnly fechaFin = DateOnly.FromDateTime(new DateTime(year, 12, 31));

        var query = from per in _context.Personas
                    join t in _context.Rols on per.RolIdFk equals t.Id
                    where t.Nombre == "Proveedor"
                    where (
                        from p in _context.MovimientoInventarios
                        where p.TipoMovInventIdFk == 2
                        where p.FechaMovimiento >= fechaInicio && p.FechaMovimiento <= fechaFin
                        select p.ResponsableIdFk
                    ).Contains(per.Id)
                    select new {
                        Proveedor = per.Nombre,
                        documento = per.NumeroDocumento
                    };

        return await query.ToListAsync();
    }


    public async Task<IEnumerable<object>> TotalVentasxProveedor()
    {
        /*  return await (
             from p in _context.Personas
             join e in _context.InventarioMedicamentos on p.Id equals e.PersonaIdFk
             join t in _context.TipoPersonas on p.TipoPersonaIdFk equals t.Id
             where t.Descripcion == "Proveedor"
            ).ToListAsync(); */
        var query = from p in _context.MovimientoInventarios
                    join e in _context.DetalleMovimientos on p.Id equals e.MovInventarioIdFk
                    join per in _context.Personas on p.ResponsableIdFk equals per.Id
                    join t in _context.Rols on per.RolIdFk equals t.Id
                    where p.TipoMovInventIdFk == 2
                    /* where t.Nombre == "Proveedor" */
                    group new {e, per} by per into g
                    select new
                    {
                        Proveedor = g.Key.Nombre,
                        CantidadProductos = g.Sum(x => x.e.Cantidad),
                        Documento = g.Key.NumeroDocumento 
                    };

        return await query.ToListAsync();
    }


}
