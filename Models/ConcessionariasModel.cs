using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeGestao.Models
{
    public class ConcessionariasModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        [Required(ErrorMessage ="Digite o nome da Concessionária")]
        [MaxLength(100), MinLength(3)]
        public string Concessionaria { get; set; }
        [Required(ErrorMessage = "Digite a rua")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Digite a cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage ="Digite o Estado. Use o formato PE, SC") ]
        [Column(TypeName = "char(2)")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Informe o CEP")]
        [Column(TypeName ="char(9)")]
        public int CEP { get; set; }
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido! example@email.com")]
        [Required(ErrorMessage ="Digite o e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a capacidade")]
        public int CapacidadeVeiculos { get; set; }

    }
}
