using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext context;
    /* private  ; */
    public UnitOfWork(ApiContext _context)
    {
        context = _context;
    }
    /* public  
    {
        get{
            if(== null){
                = new (context);
            }
            return ;
        }
    } */
    public void Dispose()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}