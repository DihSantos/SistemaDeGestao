using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
