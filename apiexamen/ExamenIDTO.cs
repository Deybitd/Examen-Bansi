using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
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
