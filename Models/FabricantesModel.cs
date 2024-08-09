using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class FabricantesModel
    {
        public int Id { get; set; }
        [Key]
        [MaxLength(100), MinLength(10)]
        public string Fabricante { get; set; }
        [MaxLength(50), MinLength(4)]
        public string PaisOrigem { get; set; }
        public int AnoFundacao { get; set; }
        [Url(ErrorMessage = "A url informada não é válida!")]
        public string Website { get; set; }

        public ICollection<VeiculosModel> Veiculos { get; set; }
    }
}
