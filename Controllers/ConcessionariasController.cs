using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Filters;

namespace SistemaDeGestao.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ConcessionariasController : Controller
    {
        private readonly IConcessionariasRepository _concessionariasRepository;
        public ConcessionariasController(IConcessionariasRepository concessionariasRepository)
        {
            _concessionariasRepository = concessionariasRepository;
        }
        public IActionResult Index()
        {
            List<ConcessionariasModel> concessionarias = _concessionariasRepository.GetAll();
            return View(concessionarias);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ConcessionariasModel concessionarias = _concessionariasRepository.ListarPorId(id);
            return View(concessionarias);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            ConcessionariasModel concessionarias = _concessionariasRepository.ListarPorId(id);
            return View(concessionarias);
        }

        public IActionResult Deletar(int id)
        {
            _concessionariasRepository.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(ConcessionariasModel concessionarias)
        {
            _concessionariasRepository.Adicionar(concessionarias);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(ConcessionariasModel concessionarias)
        {
            _concessionariasRepository.Atualizar(concessionarias);

            return RedirectToAction("Index");
        }
    }
}
