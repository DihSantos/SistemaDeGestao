using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace SistemaDeGestao.Models
{
    public class FabricantesModel
    {
        
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
