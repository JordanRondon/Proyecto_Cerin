using CapaDato;
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
        public int validarInicioSesion(string user, string passsword)
        {
            return datUser.GetInstancia.ValidarSesion(user, passsword);
        }
    }
}
