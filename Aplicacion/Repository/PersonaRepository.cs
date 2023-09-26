using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly ApiContext _context;

    public PersonaRepository(ApiContext context) : base(context)
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
        .FirstOrDefaultAsync(p => p.Id == id);
    }


    public async Task<IEnumerable<object>> TotalVentasxProveedor()
    {
        /*  return await (
             from p in _context.Personas
             join e in _context.InventarioMedicamentos on p.Id equals e.PersonaIdFk
             join t in _context.TipoPersonas on p.TipoPersonaIdFk equals t.Id
             where t.Descripcion == "Proveedor"
            ).ToListAsync(); */
        var query = from p in _context.Personas
                    join e in _context.InventarioMedicamentos on p.Id equals e.PersonaIdFk
                    join t in _context.TipoPersonas on p.TipoPersonaIdFk equals t.Id
                    where t.Descripcion == "Proveedor"
                    group e by p.Nombre into g
                    select new
                    {
                        Proveedor = g.Key,
                        CantidadProductos = g.Count()
                    };

        return await query.ToListAsync();
    }

}