using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logEquipoAccesorio
    {
        #region Singleton
        private static readonly logEquipoAccesorio instancia = new logEquipoAccesorio();
        public static logEquipoAccesorio GetInstancia => instancia;
        #endregion

        #region Metodos

        public bool insertarEquipoAccesorio(entEquipo_Accesorio equipo_accesorio) => datEquipo_Accesorio.GetInstancia.insertarEquipoAccesorio(equipo_accesorio);

        public List<entEquipo_Accesorio> ListAccsDeEquipo(int id_equipo) => datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(id_equipo);

        #endregion
    }
}
