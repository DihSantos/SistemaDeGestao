using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using SistemaDeGestao.Repository;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestao.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public VeiculosController(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        public IActionResult Index()
        {
            List<VeiculosModel> veiculos = _veiculosRepository.GetAll();
            return View(veiculos);
        }

        public IActionResult Cadastrar()
        {
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
            _veiculosRepository.Cadastrar(veiculos);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(VeiculosModel veiculos)
        {
            _veiculosRepository.Atualizar(veiculos);

            return RedirectToAction("Index");
        }
    }
}
