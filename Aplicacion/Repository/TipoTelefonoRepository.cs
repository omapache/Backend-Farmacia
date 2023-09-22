using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoTelefonoRepository : GenericRepository<TipoTelefono>, ITipoTelefono
{
    private readonly ApiContext _context;

    public TipoTelefonoRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<TipoTelefono>> GetAllAsync()
    {
        return await _context.TiposTelefonos
            .Include(p => p.Telefonos)
            .ToListAsync();
    }

    public override async Task<TipoTelefono> GetByIdAsync(int id)
    {
        return await _context.TiposTelefonos
        .Include(p => p.Telefonos)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
