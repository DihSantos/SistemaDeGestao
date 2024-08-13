using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestao.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
