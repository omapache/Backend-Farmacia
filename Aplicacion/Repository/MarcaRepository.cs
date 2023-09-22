using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MarcaRepository : GenericRepository<Marca>, IMarca
{
    protected readonly ApiContext _context;
    
    public MarcaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Marca>> GetAllAsync()
    {
        return await _context.Marcas
            .Include(p => p.Productos)
            .ToListAsync();
    }

    public override async Task<Marca> GetByIdAsync(int id)
    {
        return await _context.Marcas
        .Include(p => p.Productos)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
