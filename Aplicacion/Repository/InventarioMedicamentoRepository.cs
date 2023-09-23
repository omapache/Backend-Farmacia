using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class InventarioMedicamentoRepository : GenericRepository<InventarioMedicamento>, IInventarioMedicamento
{
    protected readonly ApiContext _context;
    
    public InventarioMedicamentoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<InventarioMedicamento>> GetAllAsync()
    {
        return await _context.InventarioMedicamentos
            .Include(p => p.Persona)
            .Include(p => p.DescripcionMedicamento)
            .ToListAsync();
    }

    public override async Task<InventarioMedicamento> GetByIdAsync(int id)
    {
        return await _context.InventarioMedicamentos
        .Include(p => p.Persona)
        .Include(p => p.DescripcionMedicamento)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<InventarioMedicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad)
    {
        return await _context.InventarioMedicamentos
            .Where(m => m.Stock < 900)
            .OrderByDescending(m => m.Id)
            .Include(p => p.Persona)
            .Include(p => p.DescripcionMedicamento)
            .Take(cantidad)
            .ToListAsync();
    }

}
