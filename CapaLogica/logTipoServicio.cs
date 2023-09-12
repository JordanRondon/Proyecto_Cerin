using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logTipoServicio
    {
        #region Singleton
        private static readonly logTipoServicio instancia = new logTipoServicio();
        public static logTipoServicio GetInstancia => instancia;
        #endregion

        #region Metodos

        public entTipoServicio BuscarTipoPorNombre(string nombre) => datTipoServicio.GetInstancia.BuscarTipoPorNombre(nombre);

        public entTipoServicio buscarTipoServicioId(int id_tipoServicio) => datTipoServicio.GetInstancia.buscarTipoServicioId(id_tipoServicio);

        public List<entTipoServicio> listarTipoServicios() => datTipoServicio.GetInstancia.listarTipoServicio();

        #endregion Metodos
    }
}
