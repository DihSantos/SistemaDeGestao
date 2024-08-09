using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class ConcessionariasModel
    {
        public int Id { get; set; }
        [Key]
        [MaxLength(100), MinLength(5)]
        public string Concessionaria { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido!")]
        public string Email { get; set; }
        public int CapacidadeVeiculos { get; set; }

        public ICollection<VendasModel> Vendas { get; set; }
    }
}
