using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
   public class RegistroViewModel
    {
        [Required(ErrorMessage ="O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string? Email { get; set; }

        [Required, MinLength(6, ErrorMessage ="A senha deve conter o mínimo de 6 caracteres")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage= "As senhas não combinam")]
        public string? ConfirmPassword { get; set; }
    }
}
