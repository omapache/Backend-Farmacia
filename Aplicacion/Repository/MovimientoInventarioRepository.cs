using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventario
{
    protected readonly ApiContext _context;
    
    public MovimientoInventarioRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoInventario>> GetAllAsync()
    {
        return await _context.MovimientoInventarios
        .Include(p => p.FormaPago)
        .Include(p => p.TipoMovimientoInventario)
        .Include(p => p.Responsable)
        .Include(p => p.Receptor)
        .Include(p => p.RecetaMedica)
        .ToListAsync();
    }

    public override async Task<MovimientoInventario> GetByIdAsync(int id)
    {
        return await _context.MovimientoInventarios
        .Include(p => p.FormaPago)
        .Include(p => p.TipoMovimientoInventario)
        .Include(p => p.Responsable)
        .Include(p => p.Receptor)
        .Include(p => p.RecetaMedica)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

   
}

/* 
public async Task<IEnumerable<Object>> InformacionContacto()
    {
        return await (
            from p in _context.Personas
            join e in _context.Emails on p.Id equals e.PersonaIdFk
            join t in _context.Telefonos on p.Id equals t.PersonaIdFk
            join r in _context.Rols on p.RolIdFk equals r.Id
            select new
            {
                Nombre = p.Nombre,
                Direccion = e.Direccion,
                Telefono = t.Numero,
                rol = r.Nombre
            }).ToListAsync();
    }
 */