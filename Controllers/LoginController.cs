using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Helper;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaDeGestao.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsuariosRepository usuariosRepository, ISessao sessao)
        {
            _usuariosRepository = usuariosRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //Se o usuario já estiver logado, redirecionar para a home

            if (_sessao.GetSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoUsuario();

            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoUsuario(usuario);
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
