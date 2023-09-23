using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logRol
    {
        #region Singleton
        private static readonly logRol instancia = new logRol();
        public static logRol GetInstancia => instancia;
        #endregion

        #region Métodos
        public List<entRol> listarRol() => datRol.GetInstancia.listarRol();

        public entRol buscarRolId(int id_rol) => datRol.GetInstancia.buscarRolId(id_rol);
        #endregion
    }
}
