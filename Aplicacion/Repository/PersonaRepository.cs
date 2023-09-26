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
            where p.RolIdFk == 2 
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
            where d.TipoMovInventIdFk == 1 && d.FechaMovimiento >= inicioAño && d.FechaMovimiento <= finAño
            group dm by new { d.ResponsableIdFk } into grupoVentas
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
}