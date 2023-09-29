using API.Dtos;
using API.Services;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class UserController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public UserController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
        _userService = userService;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var entidad = await unitofwork.Users.GetAllAsync();
        return mapper.Map<List<UserDto>>(entidad);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var entidad = await unitofwork.Users.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        return this.mapper.Map<UserDto>(entidad);
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken);
        return Ok(result);
    }

    /* [HttpPost("validate-credentials")]
    public async Task<IActionResult> ValidateCredentials(LoginDto model)
    {
        var isValid = await _userService.ValidateCredentialsAsync(model);

        if (isValid)
        {
            // Las credenciales son válidas, puedes devolver un código 200 OK.
            return Ok(new { message = "Credenciales válidas" });
        }
        else
        {
            // La autenticación falló, puedes devolver un código de error 401 Unauthorized.
            return Unauthorized(new { message = "Credenciales incorrectas" });
        }
    } */
    [HttpPost("validate-credentials")]
    public async Task<IActionResult> ValidateCredentials(LoginDto model)
    {
        try
        {
            var result = await _userService.ValidateCredentialsAsync(model);

            if (result.Id > 0)
            {
                // Las credenciales son válidas, puedes devolver un código 200 OK.
                var userDto = mapper.Map<UserDto>(result);
                return Ok(userDto.Persona.Rol.Nombre);
            }
            else
            {
                // La autenticación falló, puedes devolver un código de error 401 Unauthorized.
                return Unauthorized(new { message = "Credenciales incorrectas" });
            }
        }
        catch (InvalidOperationException)
        {
            // Manejar la excepción cuando las credenciales son incorrectas
            return Unauthorized(new { message = "Credenciales incorrectas" });
        }
    }


    [HttpPost("addrole")]
    public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
    {
        var result = await _userService.AddRoleAsync(model);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _userService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    [HttpPost("validate-credentials")]
    public async Task<IActionResult> ValidateCredentials(LoginDto model)
    {
        var isValid = await _userService.ValidateCredentialsAsync(model);

        if (isValid)
        {
            return Ok(new { message = "Credenciales válidas" });
        }
        else
        {
            return Unauthorized(new { message = "Credenciales incorrectas" });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserDto entidadDto)
    {
        if (entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<User>(entidadDto);
        unitofwork.Users.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var entidad = await unitofwork.Users.GetByIdAsync(id);
        if (entidad == null)
        {
            return NotFound();
        }
        unitofwork.Users.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }

}
