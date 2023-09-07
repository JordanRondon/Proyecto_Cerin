using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logAccesorio
    {
        #region Singleton
        private static readonly logAccesorio instancia = new logAccesorio();
        public static logAccesorio GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entAccesorio> listarAccesorio() => datAccesorio.GetInstancia.listarAccesorio();
        public entAccesorio BuscarAccesorioNombre(string nombre) => datAccesorio.GetInstancia.BuscarAccesorioNombre(nombre);
        public entAccesorio BuscarAccesorioId(int id) => datAccesorio.GetInstancia.BuscarAccesorioId(id);
        #endregion
    }
}
