using System.ComponentModel.DataAnnotations;

namespace API.Dtos;
public class ProductoProveedorDto
{

    [Required]
    public ProductoDto Producto { get; set; }
    [Required]
    public PersonaDto Proveedor { get; set; }
}
