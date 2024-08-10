using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeGestao.Models
{
    public class ConcessionariasModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        [MaxLength(100), MinLength(4)]
        public string Concessionaria { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        [Required, Column(TypeName ="char(2)")]
        public string Estado { get; set; }

        [Required, Column(TypeName ="char(9)")]
        public int CEP { get; set; }
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido!")]
        public string Email { get; set; }
        public int CapacidadeVeiculos { get; set; }

        public ICollection<VendasModel> Vendas { get; set; }
    }
}
