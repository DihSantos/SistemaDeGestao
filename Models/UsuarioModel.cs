﻿using SistemaDeGestao.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestao.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe o e-mail do usuario")]
        [EmailAddress(ErrorMessage = "Por favor informe um e-mail válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Password == senha;
        }
        
    }
}
