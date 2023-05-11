using WsApiexamen.Data.Entities;
using WsApiexamen.DTO;
using WsApiexamen.Repositories.Abstract;
using WsApiexamen.Services.Abstract;

namespace WsApiexamen.Services.Concret
{
    public class ExamenesService : IExamenesService
    {
        private readonly IExamenesRepository _repository;

        public ExamenesService(IExamenesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseCode> Actualizar(ExamenIDTO model)
        {
          var response = await _repository.Actualizar(model);
          return response;
        }

        public async Task<ResponseCode> Agregar(ExamenIDTO model)
        {
            var response = await _repository.Agregar(model);
            return response;
        }

        public async Task<List<tblExamen>> Consultar(ExamenIDTO model)
        {
            var response = await _repository.Consultar(model);
            return response;
        }

        public async Task<ResponseCode> Eliminar(int id)
        {
            var response = await _repository.Eliminar(id);
            return response;
        }
    }
}
