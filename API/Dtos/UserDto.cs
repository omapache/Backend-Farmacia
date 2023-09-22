namespace API.Dtos;
public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public PersonaDto Persona { get; set; }
}
