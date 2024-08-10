using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using SistemaDeGestao.Repository;

namespace SistemaDeGestao.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepository _usuariosRepository;
        

        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuariosRepository.GetAll();
            return View(usuarios);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuarios)
        {
            _usuariosRepository.Adicionar(usuarios);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuarios)
        {
            _usuariosRepository.Atualizar(usuarios);
            return RedirectToAction("Index");
        }
    }
}
