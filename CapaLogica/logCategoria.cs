using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCategoria
    {
        #region Singleton
        private static readonly logCategoria instancia = new logCategoria();
        public static logCategoria GetInstancia => instancia;
        #endregion

        #region Metodos

        public entCategoria BuscarCategoriaPorNombre(string nombre) => datCategoria.GetInstancia.BuscarCategoriaPorNombre(nombre);

        public entCategoria buscarCategoriaId(int id) => datCategoria.GetInstancia.buscarCategoriaId(id);

        public List<entCategoria> listarCategoriasEquipos() => datCategoria.GetInstancia.listarCategoria();

        #endregion Metodos
    }
}
