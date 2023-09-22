using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IUserRepository : IGenericRepo<User>
{ 
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByRefreshTokenAsync(string username);

}
