using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RealName { get; set; }
        public byte[] Doc { get; set; }
    }
}
