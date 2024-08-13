namespace SistemaDeGestao.Models
{
    public class VendasDto
    {
        public int Id { get; set; }
        public string ProtocoloVenda { get; set; }
        public string Concessionaria { get; set; }
        public string Fabricante { get; set; }
        public string TipoVeiculo { get; set; }
        public string VeiculoModelo { get; set; }
        public float PrecoVenda { get; set; }
        public DateTime? DataVenda { get; set; }
    }
}




