using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logMarca
    {
        #region Singleton
        private static readonly logMarca instancia = new logMarca();
        public static logMarca GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entMarca> listarMarcas() => datMarca.GetInstancia.listarMarcas();

        public bool insertaMarca(entMarca marca) => datMarca.GetInstancia.insertarMarca(marca);

        public bool editarMarca(entMarca marca) => datMarca.GetInstancia.editarMarca(marca);

        public bool eliminarMarca(entMarca marca) => datMarca.GetInstancia.eliminarMarca(marca);

        public entMarca BuscarMarcaPorId(int idMarca) => datMarca.GetInstancia.BuscarMarcaPorId(idMarca);

        #endregion
    }
}
