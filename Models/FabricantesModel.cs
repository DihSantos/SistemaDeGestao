using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace SistemaDeGestao.Models
{
    public class FabricantesModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        [MaxLength(100), MinLength(2)]
        [Required(ErrorMessage = "Digite o nome do Fabricante")]
        public string Fabricante { get; set; }
        [MaxLength(50), MinLength(2)]
        [Required(ErrorMessage = "Digite o País de Origem")]
        public string PaisOrigem { get; set; }
        [Required(ErrorMessage = "Digite o Ano")]
        public string AnoFundacao { get; set; }
        [Required(ErrorMessage = "A url do Website é obrigatória")]
        [Url(ErrorMessage = "A url informada não é válida!")]
        public string Website { get; set; }

        public virtual VeiculosModel Veiculos { get; set; }
    }
}
