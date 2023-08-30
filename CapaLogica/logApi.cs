using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logApi
    {
        #region Singleton
        private static readonly logApi instancia = new logApi();
        public static logApi GetInstancia => instancia;
        #endregion

        #region Metodos
        public entApi consultarDatosApi(string dniRuc) => datApi.GetInstancia.consultarDatosApi(dniRuc);
        #endregion
    }
}
