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

        public bool ActualizarEntregaServicio(entServicio servicio) => datServicio.GetInstancia.ActualizarEntregaServicio(servicio);

        public entServicio buscarServicio(int id_servicio) => datServicio.GetInstancia.buscarServicio(id_servicio);

        public bool ActualizarEstadoEquipo(entServicio id_servicio) => datServicio.GetInstancia.ActualizarEstadoEquipo(id_servicio);

        public List<entServicio> listarServicioCliente(int id_cliente) => datServicio.GetInstancia.listarServicioCliente(id_cliente);

        public List<entServicio> listarServicioEquipo(string serie_equipo) => datServicio.GetInstancia.listarServicioEquipo(serie_equipo);
        #endregion
    }
}
