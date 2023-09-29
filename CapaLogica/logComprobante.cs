using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace CapaLogica
{
    public class logComprobante
    {
        #region Singleton
        private static readonly logComprobante instancia = new logComprobante();
        public static logComprobante GetInstancia => instancia;
        #endregion

        public string generarComprobante(entServicio servicio, entCliente clienteSelecionado, List<entEquipo> equiposSelecionados)
        {
            return datComprobante.GetInstancia.generarComprobante(servicio,clienteSelecionado,equiposSelecionados);
        }
    }
}
