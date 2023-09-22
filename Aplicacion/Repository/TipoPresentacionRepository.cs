using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoPresentacionRepository : GenericRepository<TipoPresentacion>, ITipoPresentacion
{
    private readonly ApiContext _context;

    public TipoPresentacionRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<TipoPresentacion>> GetAllAsync()
    {
        return await _context.TipoPresentaciones
            .Include(p => p.InventarioMedicamentos)
            .ToListAsync();
    }

    public override async Task<TipoPresentacion> GetByIdAsync(int id)
    {
        return await _context.TipoPresentaciones
        .Include(p => p.InventarioMedicamentos)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
