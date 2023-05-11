using apiexamen;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Examen.Models
{
    public class EliminarViewModel
    {

        public int idExamen { get; set; }
        public bool Metodo { get; set; }
        public ResponseODTO? response { get; set; }
    }
}
