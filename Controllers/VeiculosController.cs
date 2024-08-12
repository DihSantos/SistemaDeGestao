using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SistemaDeGestao.Controllers
{
    [Authorize]
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepository _veiculosRepository;
        private readonly IFabricantesRepository _fabricantesRepository;

        public VeiculosController(IVeiculosRepository veiculosRepository, IFabricantesRepository fabricantesRepository)
        {
            _veiculosRepository = veiculosRepository;
            _fabricantesRepository = fabricantesRepository;
        }

        public IActionResult Index()
        {
            List<VeiculosModel> veiculos = _veiculosRepository.GetAll();
            return View(veiculos);
        }

        public IActionResult Cadastrar()
        {
            LoadData();
            return View();
        }

        public IActionResult Editar(int id)
        {
            VeiculosModel veiculos = _veiculosRepository.ListarPorId(id);
            return View(veiculos);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            VeiculosModel veiculos = _veiculosRepository.ListarPorId(id);
            return View(veiculos);
        }
        public IActionResult Deletar(int id)
        {
            _veiculosRepository.Deletar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(VeiculosModel veiculos)
        {
            _veiculosRepository.Adicionar(veiculos);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(VeiculosModel veiculos)
        {
            _veiculosRepository.Atualizar(veiculos);

            return RedirectToAction("Index");
        }

        private void LoadData()
        {
            ViewBag.veiculos = _veiculosRepository.GetAll();
            ViewBag.fabricantes = _fabricantesRepository.GetAll();
        }
    }
}
