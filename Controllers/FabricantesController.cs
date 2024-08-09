using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestao.Controllers
{
    public class FabricantesController : Controller
    {
        private readonly IFabricantesRepository _fabricantesRepository;
        public FabricantesController(IFabricantesRepository fabricantesRepository)
        {
            _fabricantesRepository = fabricantesRepository;
        }
        public IActionResult Index()
        {
            List<FabricantesModel> fabricantes = _fabricantesRepository.GetAll();
            return View(fabricantes);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        /*public IActionResult Editar(int id)
        {
            FabricantesModel fabricantes = _fabricantesRepository.ListarPorId(id);
            return View(fabricantes);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            FabricantesModel fabricantes = _fabricantesRepository.ListarPorId(id);
            return View(fabricantes);
        }

        public IActionResult Deletar(int id)
        {
            _fabricantesRepository.Deletar(id);
            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public IActionResult Cadastrar(FabricantesModel fabricantes)
        {
            _fabricantesRepository.Adicionar(fabricantes);

            return RedirectToAction("Index");
        }
        /*[HttpPost]
        public IActionResult Alterar(FabricantesModel fabricantes)
        {
            _fabricantesRepository.Atualizar(fabricantes);

            return RedirectToAction("Index");
        }*/
    }
}
