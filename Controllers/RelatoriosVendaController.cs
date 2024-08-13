using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using SistemaDeGestao.Repository;

namespace SistemaDeGestao.Controllers
{
    [Authorize]
    public class RelatoriosVendaController : Controller
    {
        private readonly IRelatorioVendasRepository _relatorioVendasRepository;

        public RelatoriosVendaController (IRelatorioVendasRepository relatorioVendasRepository)
        {
            _relatorioVendasRepository = relatorioVendasRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Filtrar(VendasFiltro filtro)
        {
            var vendas = _relatorioVendasRepository.FiltrarVendas(filtro).ToList();
            ViewData["Concessionaria"] = filtro.Concessionaria;
            ViewData["Fabricante"] = filtro.Fabricante;
            ViewData["TipoVeiculo"] = filtro.TipoVeiculo;
            ViewData["DataVendaMin"] = filtro.DataVendaMin?.ToString("yyyy-MM-dd");
            ViewData["DataVendaMax"] = filtro.DataVendaMax?.ToString("yyyy-MM-dd");

            return View(vendas);
        }
    }
}
