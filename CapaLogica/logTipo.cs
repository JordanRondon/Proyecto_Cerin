using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logTipo
    {
        #region Singleton
        private static readonly logTipo instancia = new logTipo();
        public static logTipo GetInstancia => instancia;
        #endregion

        #region Metodos

        public entTipo BuscarTipoPorNombre(string nombre) => datTipo.GetInstancia.BuscarTipoPorNombre(nombre);

        #endregion Metodos
    }
}
