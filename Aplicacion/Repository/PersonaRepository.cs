using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly ApiContext _context;
    
    public PersonaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
        .Include(p => p.TipoDocumento)
        .Include(p => p.TipoPersona)
        .Include(p => p.Rol)


            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .Include(p => p.TipoDocumento)
        .Include(p => p.TipoPersona)
        .Include(p => p.Rol)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    
}