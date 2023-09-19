using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MedicamentoComprado : BaseEntity
    {
        public int CompraIdFk { get; set; }
        public Compra Compra { get; set; }
        public int MedicamentoIdFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public int CantidadComprada { get; set; }
        public double PrecioCompra { get; set; }
    }
}