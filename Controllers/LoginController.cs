using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaDeGestao.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepository _usuariosRepository; 
        public LoginController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuariosRepository.GetLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Senha inválida. Por favor tente novamente";
                        }
                    }
                    else 
                    { 
                        TempData["MensagemErro"] = $"Usuário e/ou senha não encontrado(s). Por favor tente novamente";
                    }
                }
                return View("Index"); 
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o login! {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
