using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class logCertificado
    {
        #region Singleton
        private static readonly logCertificado instancia = new logCertificado();
        public static logCertificado GetInstancia => instancia;
        #endregion

        public string GenerarCerificado(entEquipo equipo, DateTime fecha,string src)
        {
            return datCertificado.GetInstancia.GenerarCertificado(equipo,fecha,src);
        }
    }
}
