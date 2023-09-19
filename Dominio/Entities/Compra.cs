using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Compra : BaseEntity
    {
        public DateTime FechaCompra { get; set; }
        public int ProveedorIdFk { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}