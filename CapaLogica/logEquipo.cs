using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logEquipo
    {
        #region Singleton
        private static readonly logEquipo instancia = new logEquipo();
        public static logEquipo GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entEquipo> listarEquipo() => datEquipo.GetInstancia.listarEquipo();
            
        public bool insertaEquipo(entEquipo equipo) => datEquipo.GetInstancia.insertarEquipo(equipo);

        public bool editarEquipo(entEquipo equipo) => datEquipo.GetInstancia.editarEquipo(equipo);

        public bool deshabilitarEquipo(entEquipo equipo) => datEquipo.GetInstancia.deshabilitarEquipo(equipo);
        #endregion
    }
}
