using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logEquipo_Servicio
    {
        #region Singleton
        private static readonly logEquipo_Servicio instancia = new logEquipo_Servicio();
        public static logEquipo_Servicio GetInstancia => instancia;
        #endregion

        #region Metodos

        public bool insertarEquipoServicio(entEquipo_Servicio servicio_detalle) => datEquipo_Servicio.GetInstancia.insertarEquipoServicio(servicio_detalle);

        public List<entEquipo> listarEquiposDeUnServicio(int id_servicio) => datEquipo_Servicio.GetInstancia.listarEquiposDeUnServicio(id_servicio);

        #endregion Metodos
    }
}
