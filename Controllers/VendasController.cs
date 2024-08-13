using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using SistemaDeGestao.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SistemaDeGestao.Controllers
{
    [Authorize(Roles = "Vendedor, Administrador, Gerente")]
    public class VendasController : Controller
    {
        private readonly IVendasRepository _vendasRepository;
        private readonly IVeiculosRepository _veiculosRepository;
        private readonly IConcessionariasRepository _concessionariasRepository;
        private readonly IVendasService _vendasService;

        public VendasController(IVeiculosRepository veiculosRepository, IConcessionariasRepository concessionariasRepository, IVendasRepository vendasRepository, IVendasService vendasService)
        {
            _veiculosRepository = veiculosRepository;
            _concessionariasRepository = concessionariasRepository;
            _vendasRepository = vendasRepository;
            _vendasService = vendasService;
        }

        public IActionResult Index()
        {
            List<VendasModel> vendas = _vendasRepository.GetAll();
         
            return View(vendas);
        }

        public IActionResult Registrar()
        {
            LoadData();
            return View();
        }

        public IActionResult DeletarConfirmacao(int Id)
        {
            VendasModel vendas = _vendasRepository.ListarPorId(Id);
            return View(vendas);
        }

        public IActionResult Deletar(int Id)
        {
            _vendasRepository.Deletar(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Registrar(VendasModel vendas)
        {
            VeiculosModel veiculos = _veiculosRepository.ListarPorId(vendas.VeiculoId);
            var veiculomodelo = veiculos.Modelo;
            vendas.VeiculoModelo = veiculomodelo;
            
            float preco = vendas.PrecoVenda;
            int idVeiculo = vendas.VeiculoId;
            if (_vendasService.PrecoValido(preco, idVeiculo))
            {
                _vendasRepository.Registrar(vendas);
                return RedirectToAction("Index");
            }
            return View(vendas);
            
        }

        public IActionResult Detalhes()
        {
            List<VendasModel> vendas = _vendasRepository.GetAll();
            return View(vendas);
        }

        private void LoadData()
        {
            ViewBag.Veiculos = _veiculosRepository.GetAll();
            ViewBag.Concessionarias = _concessionariasRepository.GetAll();
        }
    }
}
