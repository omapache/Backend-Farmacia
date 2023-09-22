using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    protected readonly ApiContext _context;
    
    public DireccionRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Direccion>> GetAllAsync()
    {
        return await _context.Direcciones
        .Include(p => p.Ciudad)
        .Include(p => p.Persona)
            .ToListAsync();
    }

    public override async Task<Direccion> GetByIdAsync(int id)
    {
        return await _context.Direcciones
        .Include(p => p.Ciudad)
        .Include(p => p.Persona)

        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}