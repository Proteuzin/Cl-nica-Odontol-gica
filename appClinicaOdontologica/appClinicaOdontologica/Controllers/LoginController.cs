using Microsoft.AspNetCore.Mvc;
using appClinicaOdontologica.Models;

namespace appClinicaOdontologica.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbClinicaOdontologicaContext _context;

        public LoginController(DbClinicaOdontologicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string login, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Login == login && u.Senha == senha);
            if (usuario != null)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Erro = "Usuário ou senha inválidos.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
