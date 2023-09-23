using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entUsuario
    {
        public int id_usuario { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int id_rol { get; set; }
        public char estado { get; set; }
        public int id_empleado { get; set; }
    }
}
