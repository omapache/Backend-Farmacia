 using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class ProductoProveedorRepository : GenericRepoIntermedia<ProductoProveedor>, IProductoProveedor
{
    private readonly ApiContext _context;

    public UserRolRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<UserRol>> GetAllAsync()
    {
        return await _context.UsersRols
            .ToListAsync();
    }

    public override async Task<UserRol> GetByIdAsync(int id)
    {
        return await _context.UsersRols
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}
