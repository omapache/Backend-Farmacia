using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly ApiContext _context;

    public RolRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Rols
            .Include(p => p.Personas)
            .ToListAsync();
    }

    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Rols
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
