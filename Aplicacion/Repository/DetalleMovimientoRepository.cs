using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimiento
{
    protected readonly ApiContext _context;
    
    public DetalleMovimientoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync()
    {
        return await _context.DetalleMovimientos
            .Include(p => p.InventarioMedicamento)
            .Include(p => p.MovimientoInventario)
            .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id)
    {
        return await _context.DetalleMovimientos
        .Include(p => p.InventarioMedicamento)
        .Include(p => p.MovimientoInventario)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<string> ObtenerProveedorMasSuministrosAsync(int año)
{
    var proveedorMasSuministros = await (
        from dm in _context.DetalleMovimientos
        join i in _context.InventarioMedicamentos on dm.InventMedicamentoIdFk equals i.Id
        join p in _context.Personas on i.PersonaIdFk equals p.Id
        join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
        join de in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals de.Id
        where p.RolIdFk == 3
        where d.TipoMovInventIdFk == 2
        where d.FechaMovimiento.Year == año
        select new
        {
            Proveedor = p.Nombre,
        })
        .GroupBy(item => item.Proveedor)
        .Select(group => new
        {
            Proveedor = group.Key,
            CantidadSuministrada = group.Count()
        })
        .OrderByDescending(item => item.CantidadSuministrada)
        .FirstOrDefaultAsync();

    if (proveedorMasSuministros != null)
    {
        return proveedorMasSuministros.Proveedor;
    }
    else
    {
        return "No se encontraron proveedores que hayan suministrado medicamentos en " + año;
    }
}

}