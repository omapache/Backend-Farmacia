using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
{
    private readonly ApiContext _context;

    public TipoDocumentoRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<TipoDocumento>> GetAllAsync()
    {
        return await _context.TipoDocumentos
            .ToListAsync();
    }

    public override async Task<TipoDocumento> GetByIdAsync(int id)
    {
        return await _context.TipoDocumentos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}