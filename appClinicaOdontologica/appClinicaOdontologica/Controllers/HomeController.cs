using System.Diagnostics;
using appClinicaOdontologica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace appClinicaOdontologica.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbClinicaOdontologicaContext _context;

        public HomeController(DbClinicaOdontologicaContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalPacientes = await _context.Pacientes.CountAsync();
            ViewBag.TotalProcedimentos = await _context.Procedimentos.CountAsync();
            ViewBag.TotalAgendamentos = await _context.Agendamentos.CountAsync();
            ViewBag.TotalUsuarios = await _context.Usuarios.CountAsync();

            var procedimentosPorTipo = await _context.Procedimentos
                .GroupBy(p => p.NomeProcedimento)
                .Select(g => new { Nome = g.Key, Quantidade = g.Count() })
                .ToListAsync();

            ViewBag.LabelsProcedimentos = procedimentosPorTipo.Select(p => p.Nome).ToList();
            ViewBag.ValoresProcedimentos = procedimentosPorTipo.Select(p => p.Quantidade).ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
