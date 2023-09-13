using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logComprobante
    {
        #region Singleton
        private static readonly logComprobante instancia = new logComprobante();
        public static logComprobante GetInstancia => instancia;
        #endregion

        public void generarComprobante(entServicio servicio) => datComprobante.GetInstancia.generarComprobante(servicio);
    }
}
