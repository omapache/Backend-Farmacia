using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    protected readonly ApiContext _context;
    
    public DireccionRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    /* public override async Task<IEnumerable<Direccion>> GetAllAsync()
    {
        return await _context.
            .Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Direccion> GetByIdAsync(int id)
    {
        return await _context.
        .Include(p => p.)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    } */
}