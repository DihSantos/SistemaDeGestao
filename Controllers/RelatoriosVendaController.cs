using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestao.Controllers
{
    public class RelatoriosVendaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
