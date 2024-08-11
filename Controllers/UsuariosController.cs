using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Filters;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using SistemaDeGestao.Repository;

namespace SistemaDeGestao.Controllers
{
    [PaginaApenasAdmin]
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

        public IActionResult Editar(int id)
        {
            UsuarioModel usuarios = _usuariosRepository.ListarPorId(id);
            return View(usuarios);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            UsuarioModel usuarios = _usuariosRepository.ListarPorId(id);
            return View(usuarios);
        }

        public IActionResult Deletar(int id)
        {
            _usuariosRepository.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuarios)
        {
            _usuariosRepository.Adicionar(usuarios);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            UsuarioModel usuario = null;

            usuario = new UsuarioModel()
            {
                Id = usuarioSemSenhaModel.Id,
                Nome = usuarioSemSenhaModel.Nome,
                Login = usuarioSemSenhaModel.Login,
                Email = usuarioSemSenhaModel.Email,
                Perfil = usuarioSemSenhaModel.Perfil
            };

            _usuariosRepository.Atualizar(usuario);
            return RedirectToAction("Index");
        }
    }
}
