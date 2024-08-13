namespace SistemaDeGestao.Models
{
    public class VendasFiltro
    {
       public DateTime? DataVendaMin { get; set; }
        public DateTime? DataVendaMax { get; set; }
        public string Concessionaria { get; set; }
        public string Fabricante { get; set; }
        public string TipoVeiculo { get; set; }
    }
}
