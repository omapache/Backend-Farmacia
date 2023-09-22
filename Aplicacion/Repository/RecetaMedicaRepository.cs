using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class RecetaMedicaRepository: GenericRepository<RecetaMedica>, IRecetaMedica
{
    protected readonly ApiContext _context;
    
    public RecetaMedicaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<RecetaMedica>> GetAllAsync()
    {
        return await _context.RecetaMedicas
            .Include(p => p.MovimientoInventario)
            .ToListAsync();
    }

    public override async Task<RecetaMedica> GetByIdAsync(int id)
    {
        return await _context.RecetaMedicas
        .Include(p => p.MovimientoInventario)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
