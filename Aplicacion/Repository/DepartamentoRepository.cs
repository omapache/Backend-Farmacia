using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    protected readonly ApiContext _context;
    
    public DepartamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    /* public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.
            .Include(p => p.)
            .ToListAsync();
    }

    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.
        .Include(p => p.)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    } */
}