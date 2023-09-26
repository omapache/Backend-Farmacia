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
            from i in _context.InventarioMedicamentos
            join dm in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals dm.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join e in _context.Emails on p.Id equals e.PersonaIdFk
            join t in _context.Telefonos on p.Id equals t.PersonaIdFk
            join r in _context.Rols on p.RolIdFk equals r.Id
            where r.Nombre == "Proveedor"
            select new
            {
                NombreMedicamento = dm.Nombre,
                NombreProveedor = p.Nombre,
                Direccion = e.Direccion,
                Telefono = t.Numero,
            }).ToListAsync();
    }

    public async Task<IEnumerable<Object>> NumeroMedicamentosPorProveedor()
    {
        return await (
            from i in _context.InventarioMedicamentos
            join dm in _context.DescripcionMedicamentos on i.DescripcionMedicamentoIdFk equals dm.Id
            join p in _context.Personas on i.PersonaIdFk equals p.Id
            join r in _context.Rols on p.RolIdFk equals r.Id
            where r.Nombre == "Proveedor"
            group i by p.Nombre into grupoProveedor
            select new
            {
                NombreProveedor = grupoProveedor.Key,
                NumeroMedicamentos = grupoProveedor.Count()
            }).ToListAsync();
    }

    public async Task<int> TotalMedicamentosVendidosMarzo()
    {
        var inicioMarzo2023 = new DateOnly(2023, 3, 1);
        var finMarzo2023 = new DateOnly(2023, 3, 31);

        var totalVendidos = await (
            from dm in _context.DetalleMovimientos
            join d in _context.MovimientoInventarios on dm.MovInventarioIdFk equals d.Id
            where d.TipoMovInventIdFk == 1
            && d.FechaMovimiento >= inicioMarzo2023 && d.FechaMovimiento <= finMarzo2023
            select dm.Cantidad
        ).SumAsync();

        return totalVendidos;
    }


}
