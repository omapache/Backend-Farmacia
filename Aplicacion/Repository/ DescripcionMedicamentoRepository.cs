using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class  DescripcionMedicamentoRepository : GenericRepository<DescripcionMedicamento>, IDescripcionMedicamento
{
    private readonly ApiContext _context;

    public  DescripcionMedicamentoRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<DescripcionMedicamento>> GetAllAsync()
    {
        return await _context.DescripcionMedicamentos
            .Include(p => p.InventarioMedicamentos)
            .ToListAsync();
    }

    public override async Task<DescripcionMedicamento> GetByIdAsync(int id)
    {
        return await _context.DescripcionMedicamentos
        .Include(p => p.InventarioMedicamentos)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
