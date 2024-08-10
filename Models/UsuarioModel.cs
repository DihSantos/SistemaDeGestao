using SistemaDeGestao.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nme do usuário")]
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        
    }
}
