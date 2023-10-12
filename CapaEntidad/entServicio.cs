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

        public int IdTipoServicio { get; set; }

        public int IdCliente { get; set; }

        public int IdEmpleado { get; set; }

        public char estado { get; set; }

        public char estadoPago { get; set; }

        public char estadoStikers { get; set; }

        public char estadoLaboratorio { get; set; }

    }
}
