namespace Dominio.Entities;

public class UserRol
{
    public int UsuarioIdFk { get; set; }
    public User User { get; set; }
    public int RolIdFk { get; set; }
    public Rol Rol { get; set; }   
}