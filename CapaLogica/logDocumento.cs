using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

        public entDocumento BuscarDocumentoPorCodigo(int id) => datDocumento.GetInstancia.BuscarDocumentoPorId(id);

        public bool insertarDocumento(string nombre, string archivo, byte[] file)
        {
            return datDocumento.GetInstancia.insertarDocumento(nombre, archivo, file);
        }

        public bool editarDocumento(entDocumento documento) => datDocumento.GetInstancia.editarDocumento(documento);
    }
}
