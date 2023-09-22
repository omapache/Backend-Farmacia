using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPago
{
    protected readonly ApiContext _context;
    
    public FormaPagoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<FormaPago>> GetAllAsync()
    {
        return await _context.FormaPagos
                .Include(p => p.MovimientoInventarios)
            .ToListAsync();
    }

    public override async Task<FormaPago> GetByIdAsync(int id)
    {
        return await _context.FormaPagos
        .Include(p => p.MovimientoInventarios)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}