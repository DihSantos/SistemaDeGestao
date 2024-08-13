using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SistemaDeGestao.Controllers
{
    [Authorize]
    public class ConcessionariasController : Controller
    {
        private readonly IConcessionariasRepository _concessionariasRepository;
        public ConcessionariasController(IConcessionariasRepository concessionariasRepository)
        {
            _concessionariasRepository = concessionariasRepository;
        }
        [Authorize(Roles = "Vendedor, Administrador, Gerente")]
        public IActionResult Index()
        {
            List<ConcessionariasModel> concessionarias = _concessionariasRepository.GetAll();
            return View(concessionarias);
        }
        [Authorize(Roles = "Administrador, Gerente")]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [Authorize(Roles = "Administrador, Gerente")]
        public IActionResult Editar(int id)
        {
            ConcessionariasModel concessionarias = _concessionariasRepository.ListarPorId(id);
            return View(concessionarias);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult DeletarConfirmacao(int id)
        {
            ConcessionariasModel concessionarias = _concessionariasRepository.ListarPorId(id);
            return View(concessionarias);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int id)
        {
            _concessionariasRepository.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(ConcessionariasModel concessionarias)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _concessionariasRepository.Adicionar(concessionarias);
                    TempData["MensagemSucesso"] = $"Concessionária cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }
              
                return View(concessionarias);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar a Concessionária! {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public IActionResult Alterar(ConcessionariasModel concessionarias)
        {
            if (ModelState.IsValid) 
            { 
                _concessionariasRepository.Atualizar(concessionarias);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Editar", concessionarias);
            }
            
        }
    }
}
