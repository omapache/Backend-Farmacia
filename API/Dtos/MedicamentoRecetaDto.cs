namespace API.Dtos;
    public class MedicamentoRecetaDto
    {
        public int Id { get; set; }
        public int RecetaIdFk { get; set; }
        public InventarioMedicamentoDto InventarioMedicamento { get; set; }
        public string Descripcion { get; set; }
    }
