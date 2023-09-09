using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logModelo
    {
        #region Singleton
        private static readonly logModelo instancia = new logModelo();
        public static logModelo GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entModelo> listarModelos() => datModelo.GetInstancia.listarModelo();

        public bool insertaModelo(entModelo modelo) => datModelo.GetInstancia.insertarModelo(modelo);

        public bool editarModelo(entModelo modelo) => datModelo.GetInstancia.editarModelo(modelo);


        public entModelo BuscarModeloPorId(int id) => datModelo.GetInstancia.BuscarModeloPorId(id);

        #endregion
    }
}
