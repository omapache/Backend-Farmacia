using System.Globalization;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class RecetaMedicaRepository : GenericRepository<RecetaMedica>, IRecetaMedica
{
    protected readonly ApiContext _context;

    public RecetaMedicaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<RecetaMedica>> GetAllAsync()
    {
        return await _context.RecetaMedicas
            .Include(p => p.Doctor)
            .Include(p => p.Paciente)
            .ToListAsync();
    }

    public override async Task<RecetaMedica> GetByIdAsync(int id)
    {
        return await _context.RecetaMedicas
        .Include(p => p.Doctor)
        .Include(p => p.Paciente)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

public async Task<IEnumerable<RecetaMedica>> ObtenerRecetaMedicaGenDesPrimEneroAsync(int year)
{
    var FechaInicio = new DateOnly(year, 1, 1);
    var FechaFin = new DateOnly(year, 12, 31);

    var recetas = await (
        from receta in _context.RecetaMedicas
        join p in _context.Personas on receta.DoctorIdFk equals p.Id
        where p.RolIdFk == 4
              && receta.FechaCreacion >= FechaInicio
              && receta.FechaCreacion <= FechaFin
        select receta
    )
    .Include(receta => receta.Doctor)
    .Include(receta => receta.Paciente)
    .ToListAsync();

    return recetas;
}


}
