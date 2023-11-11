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

        public List<entCategoria> listarCategoriasEquipos() { return datCategoria.GetInstancia.listarCategoria(); }

        public bool insertarCategoria(entCategoria categoria) => datCategoria.GetInstancia.insertarCategoria(categoria);

        public bool editarCategoria(entCategoria categoria) => datCategoria.GetInstancia.editarCategoria(categoria);
        #endregion Metodos
    }
}
