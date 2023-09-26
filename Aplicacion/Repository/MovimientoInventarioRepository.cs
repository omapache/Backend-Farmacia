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
}