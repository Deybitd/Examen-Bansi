using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Examen.Models
{
    public class ExamenModel
    {
        public int idExamen { get; set; }
        [StringLength(255)]
        public string Nombre { get; set; }
        [StringLength(255)]
        public string Descripcion { get; set; }
    }
}
