using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoMovimientoInventarioRepository : GenericRepository<TipoMovimientoInventario>, ITipoMovimientoInventario
{
    private readonly ApiContext _context;

    public TipoMovimientoInventarioRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<TipoMovimientoInventario>> GetAllAsync()
    {
        return await _context.TipoMovimientoInventarios
            .ToListAsync();
    }

    public override async Task<TipoMovimientoInventario> GetByIdAsync(int id)
    {
        return await _context.TipoMovimientoInventarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
