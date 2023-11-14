using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entModelo
    {
        public int id_modelo { get; set; }

        public string nombre { get; set; }

        public char estado { get; set; }

        public entMarca IdMarca { get; set; }

        public entCategoria IdCategoriaEquipo { get; set; }
    }
}
