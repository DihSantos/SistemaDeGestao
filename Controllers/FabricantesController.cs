using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SistemaDeGestao.Repository;

namespace SistemaDeGestao.Controllers
{
    [Authorize]
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
        [Authorize]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [Authorize]
        public IActionResult Editar(int id)
        {
            FabricantesModel fabricantes = _fabricantesRepository.ListarPorId(id);
            return View(fabricantes);
        }
        [Authorize]
        public IActionResult DeletarConfirmacao(int id)
        {
            FabricantesModel fabricantes = _fabricantesRepository.ListarPorId(id);
            return View(fabricantes);
        }
        [Authorize]
        public IActionResult Deletar(int id)
        {
            _fabricantesRepository.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(FabricantesModel fabricantes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fabricantesRepository.Adicionar(fabricantes);
                    TempData["MensagemSucesso"] = $"Fabricante cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(fabricantes);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o fabricante! {erro.Message}";
                return RedirectToAction("Index");
            }
            
                                                      
        }
        [HttpPost]
        public IActionResult Alterar(FabricantesModel fabricantes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fabricantesRepository.Atualizar(fabricantes);
                    TempData["MensagemSucesso"] = $"Fabricante Editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(fabricantes);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível Editar o fabricante! {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
