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

        public List<entMarca> listarMarcasPorCategoria(int idcategoria)
        {
            return datMarca.GetInstancia.listarMarcasPorCategoria(idcategoria);
        }

        public int insertaMarca(entMarca marca)
        {
            return datMarca.GetInstancia.insertarMarca(marca);
        }

        public List<entMarcaCategoria> ListaDetalleMarcaCategoria(int idmarca)
        {
            return datMarca.GetInstancia.ListarDetalleMarca(idmarca);
        }

        public bool editarMarca(entMarca marca) => datMarca.GetInstancia.editarMarca(marca);

        public bool deshabilitarMarca(entMarca marca) => datMarca.GetInstancia.deshabilitarMarca(marca);

        public entMarca BuscarMarcaPorId(int idMarca) => datMarca.GetInstancia.BuscarMarcaPorId(idMarca);

        public void InsertarMarcaCategoria(int id_marca,int id_categoria)
        {
            datMarca.GetInstancia.InsertarMarcaCategoria(id_marca,id_categoria);
        }

        public void eliminarMarcaCategoria(int idMarca)
        {
            datMarca.GetInstancia.eliminarMarcaCategoria(idMarca);
        }

        #endregion
    }
}
