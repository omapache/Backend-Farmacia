using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
namespace Aplicacion.Repository;
public class InventarioMedicamentoRepository : GenericRepository<InventarioMedicamento>, IInventarioMedicamento
{
    protected readonly ApiContext _context;
    
    public InventarioMedicamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<InventarioMedicamento>> GetAllAsync()
    {
        return await _context.InventarioMedicamentos
            .Include(p => p.Persona)
            .Include(p => p.DescripcionMedicamento)
            .ToListAsync();
    }

    public override async Task<InventarioMedicamento> GetByIdAsync(int id)
    {
        return await _context.InventarioMedicamentos
        .Include(p => p.Persona)
        .Include(p => p.DescripcionMedicamento)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<InventarioMedicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad)
    {
        return await _context.InventarioMedicamentos
            .Where(m => m.Stock < 900)
            .OrderByDescending(m => m.Id)
            .Include(p => p.Persona)
            .Include(p => p.DescripcionMedicamento)
            .Take(cantidad)
            .ToListAsync();
    }
    public async Task<IEnumerable<Object>> ObtenerMedicamentosCaducadosAsync(DateOnly fechaLimite)
    {
        var medicamentosCaducados = await (
            from i in _context.InventarioMedicamentos
            join d in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals d.Id
            where i.FechaExpiracion < fechaLimite
            select new 
            {
                Nombre = d.Nombre,
                Stock = i.Stock,
                FechaExpiracion = i.FechaExpiracion
            }).ToListAsync();

        return medicamentosCaducados;
    }
    public async Task<IEnumerable<Object>> ObtenerMedicamentosSinExpirarAsync()
    {
        DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);
        var medicamentosNoVendidos = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            join de in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals de.Id
            where d.TipoMovInventIdFk == 1
            where i.FechaExpiracion < fechaActual
            select new 
            {
                Nombre = de.Nombre,
                Stock = i.Stock,
                FechaExpiracion = i.FechaExpiracion
            }).ToListAsync();

        return medicamentosNoVendidos;
    }
    public async Task<IEnumerable<Object>> ObtenerMedicamentosVendidoEspecificoAsync(string Nombre)
    {
        var medicamentosNoVendidos = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            join de in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals de.Id
            where d.TipoMovInventIdFk == 2
            where p.Nombre.ToLower() == Nombre.ToLower() 
            select new 
            {
                Nombre = de.Nombre,
                cantidad = dm.Cantidad,
            }).ToListAsync();

        return medicamentosNoVendidos;
    }
    public async Task<IEnumerable<Object>> ObtenerPacienteCompradoEspecificoAsync(string medicina)
    {
        var medicamentosNoVendidos = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            join de in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals de.Id
            where d.TipoMovInventIdFk == 2
            where de.Nombre.ToLower() == medicina.ToLower() 
            select new 
            {
                Nombre = p.Nombre,
            }).ToListAsync();

        return medicamentosNoVendidos;
    }

    public async Task<int> TotalVentasMedicamento(string NombreMedicamento)
    {
        DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

        var totalVentasMedicamento = await (
            from dm in _context.DetalleMovimientos
            join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            join de in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals de.Id
            where d.TipoMovInventIdFk == 1 && de.Nombre == NombreMedicamento
            where i.FechaExpiracion < fechaActual
            select i.Stock
        ).SumAsync();

        return totalVentasMedicamento;
    }

}
