using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using SistemaDeGestao.Repository;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestao.Controllers
{
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

        public IActionResult DeletarConfirmacao(int ProtocoloVenda)
        {
            VendasModel veiculos = _vendasRepository.ListarPorId(ProtocoloVenda);
            return View(veiculos);
        }

        public IActionResult Deletar(int ProtocoloVenda)
        {
            _vendasRepository.Deletar(ProtocoloVenda);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Registrar(VendasModel vendas)
        {
            _vendasRepository.Registrar(vendas);
            //LoadData();
            //float preco = PrecoVenda;
            //int idVeiculo = VeiculoModelo;
            //if (_vendasService.PrecoValido(preco, idVeiculo)) 

            return RedirectToAction("Index");
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        private void LoadData()
        {
            ViewBag.Veiculos = _veiculosRepository.GetAll();
            ViewBag.Concessionarias = _concessionariasRepository.GetAll();
        }
    }
}
