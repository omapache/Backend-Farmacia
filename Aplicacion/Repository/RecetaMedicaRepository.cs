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
        /* DateOnly Fecha = DateOnly.Parse("January 01, "+year, CultureInfo.InvariantCulture);
        DateOnly FechaFin = DateOnly.Parse("January 01, "+year, CultureInfo.InvariantCulture); */
        
        var Fecha = new DateOnly(year, 1, 1);
        var FechaFin = new DateOnly(year, 12, 31);
        
        return await _context.RecetaMedicas
        .Where(p => p.FechaCreacion > Fecha && p.FechaCreacion < FechaFin)
        .Include(p => p.Doctor)
        .Include(p => p.Paciente)
        .ToListAsync();
    }
}
