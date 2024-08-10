﻿using SistemaDeGestao.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Informe o login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe o e-mail do usuario")]
        [EmailAddress(ErrorMessage ="Por favor informe um e-mail válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
        
    }
}
