using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsApiexamen.DTO;
using WsApiexamen.Services.Abstract;

namespace WsApiexamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly IExamenesService _examenesService;

        public ExamenController(IExamenesService examenesService)
        {
           _examenesService = examenesService;
        }
        [HttpGet]
        public async Task<IActionResult> Consultar(ExamenIDTO model)
        {
           var _HttpResponse = new ObjectResult(null);
            var examenes = await  _examenesService.Consultar(model);
            _HttpResponse = StatusCode(StatusCodes.Status200OK,examenes);
            return _HttpResponse;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var _HttpResponse = new ObjectResult(null);
            var responseObj = new ResponseODTO();
            var response = await _examenesService.Eliminar(id);
            responseObj.message = response.Descripcion;
            responseObj.status = response.Codigo == 0 ? true : false;
            _HttpResponse = response.Codigo == 0 ? StatusCode(StatusCodes.Status200OK, responseObj) : StatusCode(StatusCodes.Status400BadRequest, responseObj);
            return _HttpResponse;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(ExamenIDTO model)
        {
            var _HttpResponse = new ObjectResult(null);
            var responseObj = new ResponseODTO();
            var response = await _examenesService.Agregar(model);
            responseObj.message = response.Descripcion;
            responseObj.status = response.Codigo == 0 ? true : false;
            _HttpResponse = response.Codigo == 0 ? StatusCode(StatusCodes.Status200OK, responseObj) : StatusCode(StatusCodes.Status400BadRequest, responseObj);
            return _HttpResponse;
        }
        [HttpPut]
        public async Task<IActionResult> Actualizar(ExamenIDTO model)
        {
            var _HttpResponse = new ObjectResult(null);
            var responseObj = new ResponseODTO();
            var response = await _examenesService.Actualizar(model);
            responseObj.message = response.Descripcion;
            responseObj.status = response.Codigo == 0 ? true : false;
            _HttpResponse = response.Codigo == 0 ? StatusCode(StatusCodes.Status200OK, responseObj) : StatusCode(StatusCodes.Status400BadRequest, responseObj);
            return _HttpResponse;
        }
    }
}
