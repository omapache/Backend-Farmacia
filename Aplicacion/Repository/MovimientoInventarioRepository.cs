using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MovimientoInventarioRepository : GenericRepository<MovimientoInventario>, IMovimientoInventario
{
    protected readonly ApiContext _context;

    public MovimientoInventarioRepository(ApiContext context) : base(context)
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
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    
    public async Task<IEnumerable<object>> ProvSinVentasUltAño()
{
    DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Today);
    DateOnly fechaHace1Año = fechaActual.AddDays(-365);

    var query = from per in _context.Personas
                join t in _context.Rols on per.RolIdFk equals t.Id
                where t.Nombre == "Proveedor"
                where !(
                    from p in _context.MovimientoInventarios
                    where p.TipoMovInventIdFk == 2
                    where p.FechaMovimiento > fechaHace1Año
                    select p.ResponsableIdFk
                ).Contains(per.Id)
                select per;

    return await query.ToListAsync();
}


    public async Task<IEnumerable<object>> TotalVentasxProveedor()
    {
        /*  return await (
             from p in _context.Personas
             join e in _context.InventarioMedicamentos on p.Id equals e.PersonaIdFk
             join t in _context.TipoPersonas on p.TipoPersonaIdFk equals t.Id
             where t.Descripcion == "Proveedor"
            ).ToListAsync(); */
        var query = from p in _context.MovimientoInventarios
                    join e in _context.DetalleMovimientos on p.Id equals e.MovInventarioIdFk
                    join per in _context.Personas on p.ResponsableIdFk equals per.Id
                    join t in _context.Rols on per.RolIdFk equals t.Id
                    where p.TipoMovInventIdFk == 2
                    where t.Nombre == "Proveedor"
                    group e.Cantidad by p into g
                    select new
                    {
                        Proveedor = g.Key,
                        CantidadProductos = g.Sum()
                    };

        return await query.ToListAsync();
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