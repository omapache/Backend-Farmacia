namespace Dominio.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int PersonaIdFk { get; set; }
    public Persona Persona { get; set; }
    public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<UserRol> UsersRols { get; set; }
}
/*
API:
AspNetCoreRateLimit
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.AspNetCore.Mvc.Versioning
Microsoft.AspNetCore.OpenApi
Microsoft.EntityFrameworkCore.Design
System.IdentityModel.Tokens.Jwt

DOMINIO:
FluentValidation.AspNetCore
itext7.pdfhtml
Microsoft.EntityFrameworkCore

PERSISTENCIA:
Microsoft.EntityFrameworkCore
Pomelo.EntityFrameworkCore.MySql
*/