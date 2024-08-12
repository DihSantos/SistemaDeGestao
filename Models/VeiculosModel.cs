using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class VeiculosModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Digite um Modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Digite um ano")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public string AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Digite um Valor")]
        public float Preco { get; set; }
        public string? Fabricante { get; set; }
        [Required(ErrorMessage = "Escolha um tipo")]
        public string TipoVeiculo { get; set; }
        [MaxLength(500)]
        public string? Descricao { get; set; }
        [ForeignKey("Fabricante")]
        public FabricantesModel Fabricantes { get; set; }
        public virtual VendasModel Vendas { get; set; }
    }
}
