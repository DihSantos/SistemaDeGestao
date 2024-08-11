using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Filters;

namespace SistemaDeGestao.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
