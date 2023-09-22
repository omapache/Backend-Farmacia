using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    protected readonly ApiContext _context;
    
    public PersonaRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
            .Include(p => p.Emails)
            .Include(p => p.Telefonos)
            .Include(p => p.Direcciones)
            .Include(p => p.InventarioMedicamentos)
            //NO SE SI ESTO ES SOLO LA INTERMEDIA O LA DEL OTRO LADO TAMBIEN SE TRAE 
            .Include(p => p.Productos)
            .Include(p => p.ProductoProveedores)
            //---------------------
            .Include(p => p.MovimientoInventariosReceptor)
            .Include(p => p.MovimientoInventariosResponsable)

            .Include(p => p.RecetaMedicaDoctor)
            .Include(p => p.RecetaMedicaPaciente)

            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas
        .Include(p => p.Emails)
        .Include(p => p.Telefonos)
        .Include(p => p.Direcciones)
        .Include(p => p.InventarioMedicamentos)
        //NO SE SI ESTO ES SOLO LA INTERMEDIA O LA DEL OTRO LADO TAMBIEN SE TRAE 
        .Include(p => p.Productos)
        .Include(p => p.ProductoProveedores)
        //---------------------
        .Include(p => p.MovimientoInventariosReceptor)
        .Include(p => p.MovimientoInventariosResponsable)

        .Include(p => p.RecetaMedicaDoctor)
        .Include(p => p.RecetaMedicaPaciente)

        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}