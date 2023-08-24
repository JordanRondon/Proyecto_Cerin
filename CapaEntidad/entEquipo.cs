using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entEquipo
    {
        public int IdEquipo { get; set; }

        public string SerieEquipo { get; set; }

        public string Modelo { get; set; }

        public string Observaciones { get; set; }

        public string Recomendaciones { get; set; }

        public string Estado { get; set; }

        public int IdTipo { get; set; }

        public int IdMarca { get; set; }
    }
}
