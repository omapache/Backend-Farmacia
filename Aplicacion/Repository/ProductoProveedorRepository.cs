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
            .Include(p => p.Producto)
            .Include(p => p.Proveedor)
            .ToListAsync();
    }

    public override async Task<ProductoProveedor> GetByIdAsync(int id)
    {
        return await _context.ProductoProveedores
        .Include(p => p.Producto)
        .Include(p => p.Proveedor)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
