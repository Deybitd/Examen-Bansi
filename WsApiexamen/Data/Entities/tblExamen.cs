using System.ComponentModel.DataAnnotations;

namespace WsApiexamen.Data.Entities
{
    public class tblExamen
    {
        public int idExamen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
