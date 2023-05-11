using WsApiexamen.Data.Entities;
using WsApiexamen.DTO;

namespace WsApiexamen.Services.Abstract
{
    public interface IExamenesService
    {
        public Task<ResponseCode> Actualizar(ExamenIDTO model);
        public Task<ResponseCode> Eliminar(int id);
        public Task<ResponseCode> Agregar(ExamenIDTO model);
        public Task<List<tblExamen>> Consultar(ExamenIDTO model);
    }
}
