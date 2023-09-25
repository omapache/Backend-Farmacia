using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class ProductoProveedorRepository: GenericRepository<ProductoProveedor>, IProductoProveedor
{
    protected readonly ApiContext _context;
    
    public ProductoProveedorRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ProductoProveedor>> GetAllAsync()
    {
        return await _context.ProductoProveedores
            /* .Include(p => p.Producto).ThenInclude(p => p.InventarioMedicamento)
            .Include(p => p.Producto).ThenInclude(p => p.InventarioMedicamento.DescripcionMedicamento)
            .Include(p => p.Producto).ThenInclude(p => p.InventarioMedicamento.DescripcionMedicamento.TipoPresentacion)
            .Include(p => p.Producto).ThenInclude(p => p.Marca)
            .Include(p => p.Proveedor).ThenInclude(p => p.TipoPersona)
            .Include(p => p.Proveedor).ThenInclude(p => p.TipoDocumento)
            .Include(p => p.Proveedor).ThenInclude(p => p.Rol) */
            .Include(p => p.Proveedor).ThenInclude(p => p.Rol)
            .ToListAsync();
    }
    

    public override async Task<ProductoProveedor> GetByIdAsync(int id)
    {
        return await _context.ProductoProveedores
        .Include(p => p.Producto).ThenInclude(p => p.InventarioMedicamento)
        .Include(p => p.Producto).ThenInclude(p => p.InventarioMedicamento.DescripcionMedicamento)
        .Include(p => p.Producto).ThenInclude(p => p.InventarioMedicamento.DescripcionMedicamento.TipoPresentacion)
        .Include(p => p.Producto).ThenInclude(p => p.Marca)
        .Include(p => p.Proveedor).ThenInclude(p => p.TipoPersona)
        .Include(p => p.Proveedor).ThenInclude(p => p.TipoDocumento)
        .Include(p => p.Proveedor).ThenInclude(p => p.Rol)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    
    
    
}
