using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class MedicamentoVendido : BaseEntity
    {
        public int VentaIdFk { get; set; }
        public Venta Venta { get; set; }
        public int MedicamentoIdFk { get; set; }
        public Medicamento Medicamento { get; set; }
        public int CantidadVendida { get; set; }
        public double Precio { get; set; }
    }
}