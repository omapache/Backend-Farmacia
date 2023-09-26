using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventario
{
    protected readonly ApiContext _context;
    
    public MovimientoInventarioRepository(ApiContext context) : base (context)
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
        .FirstOrDefaultAsync(p =>  p.Id == id);
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
    


}