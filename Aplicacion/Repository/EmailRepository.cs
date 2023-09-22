using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class EmailRepository : GenericRepository<Email>, IEmail
{
    protected readonly ApiContext _context;
    
    public EmailRepository(ApiContext context) : base (context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Email>> GetAllAsync()
    {
        return await _context.Emails
            .ToListAsync();
    }

    public override async Task<Email> GetByIdAsync(int id)
    {
        return await _context.Emails
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}