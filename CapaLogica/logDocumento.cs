using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logDocumento
    {
        #region Singleton
        private static readonly logDocumento instancia = new logDocumento();
        public static logDocumento GetInstancia => instancia;
        #endregion

        public entDocumento buscarDocumentoId(string nombre)
        {
            return datDocumento.GetInstancia.BuscarDocumentoPorNombre(nombre);
        }


    }
}
