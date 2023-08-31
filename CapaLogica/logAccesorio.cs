using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logAccesorio
    {
        #region Singleton
        private static readonly logAccesorio instancia = new logAccesorio();
        public static logAccesorio GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entAccesorio> listarAccesorio() => datAccesorio.GetInstancia.listarAccesorio();
        #endregion
    }
}
