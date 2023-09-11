using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Equipo_servicio
    {
        public int id_equipo { get; set; }
        public int id_servicio { get; set; }
        public string Observaciones_preliminares { get; set; }
        public string observaciones_finales { get; set; }
    }
}
