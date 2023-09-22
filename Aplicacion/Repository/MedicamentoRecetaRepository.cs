using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class MedicamentoRecetaRepository : GenericRepository<MedicamentoReceta>, IMedicamentoReceta
{
    protected readonly ApiContext _context;
    
    public MedicamentoRecetaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MedicamentoReceta>> GetAllAsync()
    {
        return await _context.MedicamentoRecetas
            .ToListAsync();
    }

    public override async Task<MedicamentoReceta> GetByIdAsync(int id)
    {
        return await _context.MedicamentoRecetas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
