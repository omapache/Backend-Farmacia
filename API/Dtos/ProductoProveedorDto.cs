using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace API.Dtos
{
    public class ProductoProveedorDto
    {
        public int Id { get; set; }
        public int ProductoIdFk { get; set; }
        public int ProveedorIdFk { get; set; }
        public PersonaDto Proveedor { get; set; }
        public ProductoDto Producto { get; set; }

    }
}