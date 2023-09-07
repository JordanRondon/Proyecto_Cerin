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

        public entEquipo_Accesorio BuscarEquipoAccesorio(int idEquipo, int id_accesorio) => datEquipo_Accesorio.GetInstancia.BuscarEquipoAccesorio(idEquipo,id_accesorio);

        public bool EditarEquipoAccesorio(entEquipo_Accesorio det_equipo_Accesorio)
        {
            return datEquipo_Accesorio.GetInstancia.EditarEquipoAccesorio(det_equipo_Accesorio);
        }

        public List<entEquipo_Accesorio> listar()
        {
            return datEquipo_Accesorio.GetInstancia.Listar();
        }

        public bool EliminarDetalle(int id_equipo, int id_accesorio)
        {
            return datEquipo_Accesorio.GetInstancia.EliminarDetalle(id_equipo, id_accesorio);
        }
        #endregion
    }
}
