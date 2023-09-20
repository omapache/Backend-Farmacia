using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepository<Pais>, IPais
{
    protected readonly ApiContext _context;
    
    public PaisRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    /* public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.
            .Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.
        .Include(p => p.)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    } */
}