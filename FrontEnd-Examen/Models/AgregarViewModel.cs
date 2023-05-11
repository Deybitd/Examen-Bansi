using apiexamen;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Examen.Models
{
    public class AgregarViewModel
    {
        public ExamenIDTO? data { get; set; } 
        public int idExamen { get; set; }
        [StringLength(255)]
        public string Nombre { get; set; }
        [StringLength(255)]
        public string Descripcion { get; set; }
        public bool Metodo { get; set; }
        public ResponseODTO? response { get; set; }
    }
}
