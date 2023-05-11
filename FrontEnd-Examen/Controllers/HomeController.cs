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

            ClsExamen repositorio = new ClsExamen(false, "Server=localhost;Database=BdiExamen;User Id=DEVUSER;Password=5207;Encrypt=False;");
            ExamenIDTO model = new ExamenIDTO { Id = 4, Descripcion = "prueba3", Nombre = "Prueba" };
            var response = await repositorio.ConsultarExamenAsync(model);
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