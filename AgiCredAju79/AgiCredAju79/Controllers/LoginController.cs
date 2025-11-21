using Microsoft.AspNetCore.Mvc;

namespace AgiCredAju79.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration Configuration { get; }

        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return PartialView();
        }

        public IActionResult ActionLogin(string keyLogin)
        {
            var credentials = Configuration.GetSection("credentials");
            string? adminKeyLogin = credentials["admin-key-login"];

            if (keyLogin == adminKeyLogin)
            {
                HttpContext.Session.SetString("KEY-EEW-55D", "true");
                return Redirect("../NotaEmprestimoes");
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("KEY-EEW-55D", "false");
            return Redirect("../");
        }
    }
}
