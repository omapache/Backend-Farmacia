using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class TelefonoRepository : GenericRepository<Telefono>, ITelefono
{
    protected readonly ApiContext _context;
    
    public TelefonoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Telefono>> GetAllAsync()
    {
        return await _context.Telefonos
            .ToListAsync();
    }

    public override async Task<Telefono> GetByIdAsync(int id)
    {
        return await _context.Telefonos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}