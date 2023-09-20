using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    protected readonly ApiContext _context;
    
    public CiudadRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    /* public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.
            .Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.
        .Include(p => p.)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    } */
}