using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaDeGestao.Models
{
    public class VendasModel
    {
        [Key]
        public int Id { get; set; }
        public string ProtocoloVenda { get; set; }

        public int VeiculoId { get; set; }

        public string VeiculoModelo { get; set; }

        public string Concessionaria { get; set; }
        [Required(ErrorMessage = "O cpf é obrigatório!")]
        [Column(TypeName = "char(11)")]
        public string ClienteCPF { get; set; }

        public string NomeCliente { get; set; }
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string FoneCliente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [ReadOnly(true)]
        public DateTime? DataVenda { get; set; }
        public float PrecoVenda { get; set; }

        [ForeignKey("VeiculoId")]
        public VeiculosModel Veiculos { get; set; }

        [ForeignKey("Concessionaria")]
        public ConcessionariasModel Concessionarias { get; set; }
    }
}
