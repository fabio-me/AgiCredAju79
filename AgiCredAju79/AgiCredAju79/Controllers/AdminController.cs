using Microsoft.AspNetCore.Mvc;

namespace AgiCredAju79.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrosPendentes()
        {
            return View();
        }
    }
}
