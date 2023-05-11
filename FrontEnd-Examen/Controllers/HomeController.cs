using apiexamen;
using FrontEnd_Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontEnd_Examen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ClsExamen repositorio = new ClsExamen(true, "https://localhost:7029/api/Examen");
            ExamenIDTO model = new ExamenIDTO { idExamen = 4, Descripcion = "pruebaapi2", Nombre = "update" };
            var response = await repositorio.EliminarExamenAsync(4);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}