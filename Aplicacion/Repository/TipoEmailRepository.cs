using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoEmailRepository : GenericRepository<TipoEmail>, ITipoEmail
{
    private readonly ApiContext _context;

    public TipoEmailRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<TipoEmail>> GetAllAsync()
    {
        return await _context.TiposEmails
            .Include(p => p.Descripcion)
            .ToListAsync();
    }

    public override async Task<TipoEmail> GetByIdAsync(int id)
    {
        return await _context.TiposEmails
        .Include(p => p.Descripcion)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}