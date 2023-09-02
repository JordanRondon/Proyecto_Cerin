using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCliente
    {
        #region Singleton
        private static readonly logCliente instancia = new logCliente();
        public static logCliente GetInstancia => instancia;
        #endregion

        #region Metodos

        public List<entCliente> listarClientes() => datCliente.GetInstancia.listarCliente();

        public bool insertarCliente(entCliente cliente) => datCliente.GetInstancia.insertarCliente(cliente);

        public bool editarCliente(entCliente cliente) => datCliente.GetInstancia.editarCliente(cliente);

        

        #endregion
    }
}
