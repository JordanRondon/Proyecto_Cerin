using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logUser
    {
        #region Singleton
        private static readonly logUser instancia = new logUser();
        public static logUser GetInstancia => instancia;
        #endregion
        public int validarInicioSesion(string user, string passsword) => datUser.GetInstancia.ValidarSesion(user, passsword);

        public List<entUsuario> listarUsuarios() => datUser.GetInstancia.listarUsuarios();

        public entUsuario buscarUsuario(int id_usuario) => datUser.GetInstancia.buscarUsuario(id_usuario);

        public int insertarUsuario(entUsuario usuario) => datUser.GetInstancia.insertarUsuario(usuario);

        public bool editarUsuario(entUsuario usuario) => datUser.GetInstancia.editarUsuario(usuario);

        public bool deshabilitarUsuario(entUsuario usuario) => datUser.GetInstancia.deshabilitarUsuario(usuario);
    }
}
