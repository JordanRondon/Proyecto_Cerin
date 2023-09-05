using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logServicio
    {
        #region Singleton
        private static readonly logServicio instancia = new logServicio();
        public static logServicio GetInstancia => instancia;
        #endregion

        #region Metodos

        public int insertarServicio(entServicio servicio) => datServicio.GetInstancia.insertarServicio(servicio);

        #endregion
    }
}
