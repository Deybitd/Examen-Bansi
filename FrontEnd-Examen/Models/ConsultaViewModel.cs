using apiexamen;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Examen.Models
{
    public class ConsultaViewModel
    {
        public List<ExamenIDTO>? Examenes { get; set; }
        [StringLength(255)]
        public string Nombre { get; set; }
        [StringLength(255)]
        public string Descripcion { get; set; }
        public bool Metodo { get; set; }
    }
}
