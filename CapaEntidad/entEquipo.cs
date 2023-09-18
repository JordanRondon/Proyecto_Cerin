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
        public string SerieEquipo { get; set; }

        public char Estado { get; set; }

        public int id_modelo { get; set; }

        public int IdTipo { get; set; }

        public int IdMarca { get; set; }

        public int id_categoria { get; set; }

        public string otrosaccesorios { get; set; }
    }
}
