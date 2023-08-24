using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entServicio
    {
        public int IdServicio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public int IdTipo { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }

    }
}
