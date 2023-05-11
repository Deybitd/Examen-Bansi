using WsApiexamen.Data.Entities;
using WsApiexamen.DTO;

namespace WsApiexamen.Repositories.Abstract
{
    public interface IExamenesRepository
    {
        public Task<ResponseCode> Actualizar(ExamenIDTO model);
        public Task<ResponseCode> Eliminar(int id);
        public Task<ResponseCode> Agregar(ExamenIDTO model);
        public Task<List<tblExamen>> Consultar(ExamenIDTO model);
    }
}
