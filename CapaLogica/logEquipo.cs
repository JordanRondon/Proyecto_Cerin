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

        public List<entEquipo> listarEquipoDisponible() => datEquipo.GetInstancia.listarEquipoDisponible();

        public int insertaEquipo(entEquipo equipo) => datEquipo.GetInstancia.insertarEquipo(equipo);

        public bool editarEquipo(entEquipo equipo) => datEquipo.GetInstancia.editarEquipo(equipo);

        public bool deshabilitarEquipo(entEquipo equipo) => datEquipo.GetInstancia.deshabilitarEquipo(equipo);

        public List<entEquipo> listarEquipoModelo(string modelo) => datEquipo.GetInstancia.listarEquipoModelo(modelo);

        public List<entEquipo> listarEquipoSerie(string serie) => datEquipo.GetInstancia.listarEquipoSerie(serie);

        public List<entEquipo> listarEquipoMarca(string marca) => datEquipo.GetInstancia.listarEquipoMarca(marca);

        public entEquipo buscarEquipoID(int id_equipo) => datEquipo.GetInstancia.buscarEquipoID(id_equipo);
        #endregion
    }
}
