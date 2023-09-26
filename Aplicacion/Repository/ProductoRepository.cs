using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    protected readonly ApiContext _context;
    
    public ProductoRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.InventarioMedicamento)
            .Include(p => p.Marca)
            .ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Productos
        .Include(p => p.InventarioMedicamento)
        .Include(p => p.Marca)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<IEnumerable<Object>> InformacionContacto()
    {
        return await (
            from p in _context.Personas
            join e in _context.Emails on p.Id equals e.PersonaIdFk
            join t in _context.Telefonos on p.Id equals t.PersonaIdFk
            join r in _context.Rols on p.RolIdFk equals r.Id
            where r.Nombre == "Proveedor" // Filtrar por RolIdFk igual a 3 (proveedores)
            select new
            {
                Nombre = p.Nombre,
                Direccion = e.Direccion,
                Telefono = t.Numero,
            }).ToListAsync();
    }

    public async Task<Producto> ObtenerMedicamentoMasCaroAsync()
    {
        var productoMasCaro = await _context.Productos
        .OrderByDescending(p => p.Precio)
        .FirstOrDefaultAsync();

        return productoMasCaro;
    }

}
