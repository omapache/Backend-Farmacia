namespace API.Dtos;
public class PersonaDto
{
    public int Id { get; set;}
    public string Nombre { get; set; }
    public int TipoPersonaIdFk { get; set; }
    public int TipoDocumentoIdFk { get; set; }
    public int RolIdFk { get; set; }
    public string NumeroDocumento { get; set; }
/*     public TipoPersonaDto TipoPersona { get; set; }
    public TipoDocumentoDto TipoDocumento { get; set; }
    public RolDto Rol { get; set; } */
    public TipoDocumentoDto TipoDocumento { get; set; }
    public List<TipoDocumentoDto> TipoDocumentos{ get; set; }
    public RolDto Rol { get; set; }
}
