namespace Dominio.Entities;

public class TipoEmail : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Email> Emails { get; set; }
}