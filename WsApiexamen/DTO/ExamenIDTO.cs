using System.ComponentModel.DataAnnotations;

namespace WsApiexamen.DTO
{
    public class ExamenIDTO
    {
        public int idExamen { get; set; }
        [StringLength(255)]
        public string Nombre { get; set; }
        [StringLength(255)]
        public string Descripcion { get; set; }
    }
}
