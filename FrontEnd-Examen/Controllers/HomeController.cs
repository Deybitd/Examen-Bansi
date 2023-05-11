using apiexamen;
using FrontEnd_Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontEnd_Examen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //ClsExamen repositorio = new ClsExamen(true, "https://localhost:7029/api/Examen");
            //ExamenIDTO model = new ExamenIDTO { idExamen = 4, Descripcion = "pruebaapi2", Nombre = "update" };
            //var response = await repositorio.EliminarExamenAsync(4);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Consultar(ConsultaViewModel modelView)
        {   
            if(ModelState.IsValid)
            {
                if(modelView.Nombre != null && modelView.Descripcion != null)
                {
                    ClsExamen repositorio = null;
                    if (modelView.Metodo)
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("API"));
                    }
                    else
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("DB"));
                    }
                   
                    ExamenIDTO model = new ExamenIDTO {  Descripcion = modelView.Descripcion, Nombre = modelView.Nombre };
                    var response = await repositorio.ConsultarExamenAsync(model);
                    modelView.Examenes = response;
                    return View(modelView);
                }
            }
            return View();
        }
        public async Task<IActionResult> Agregar(AgregarViewModel modelView)
        {
            if (ModelState.IsValid)
            {   

                if (modelView.idExamen != null && modelView.Descripcion != null && modelView.Nombre != null )
                {
                    ClsExamen repositorio = null;
                    if (modelView.Metodo)
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("API"));
                    }
                    else
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("DB"));
                    }

                    modelView.data = new ExamenIDTO { idExamen = modelView.idExamen, Descripcion = modelView.Descripcion, Nombre = modelView.Nombre };
                    var response = await repositorio.AgregarExamenAsync(modelView.data);
                    modelView.response = response;
                    return View(modelView);
                }
            }
            return View();
        }

        public async Task<IActionResult> Actualizar(ActualizarViewModel modelView)
        {
            if (ModelState.IsValid)
            {

                if (modelView.idExamen != null && modelView.Descripcion != null && modelView.Nombre != null)
                {
                    ClsExamen repositorio = null;
                    if (modelView.Metodo)
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("API"));
                    }
                    else
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("DB"));
                    }

                    modelView.data = new ExamenIDTO { idExamen = modelView.idExamen, Descripcion = modelView.Descripcion, Nombre = modelView.Nombre };
                    var response = await repositorio.ActualizarExamenAsync(modelView.data);
                    modelView.response = response;
                    return View(modelView);
                }
            }
            return View();
        }

        public async Task<IActionResult> Eliminar(EliminarViewModel modelView)
        {
            if (ModelState.IsValid)
            {

                if (modelView.idExamen != 0)
                {
                    ClsExamen repositorio = null;
                    if (modelView.Metodo)
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("API"));
                    }
                    else
                    {
                        repositorio = new ClsExamen(modelView.Metodo, _configuration.GetConnectionString("DB"));
                    }

                    
                    var response = await repositorio.EliminarExamenAsync(modelView.idExamen);
                    modelView.response = response;
                    return View(modelView);
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}