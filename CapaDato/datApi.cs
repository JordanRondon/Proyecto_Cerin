using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class datApi
    {
        #region Singleton
        private static readonly datApi instancia = new datApi();
        public static datApi GetInstancia => instancia;
        #endregion

        #region Metodos
        public entApi consultarDatosApi(string dniRuc)
        {
            entApi datos = null;

            try
            {
                if (dniRuc.Length == 11)
                {
                    dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/ruc/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImpvcmRhbmFuZ2Vscm9uZG9ucG96b0BnbWFpbC5jb20ifQ._sY7Mt0qrxCqH2uZH745-57025MYCXrnIZeg-whqgFs");

                    if (respuesta.success != false)
                    {
                        datos = new entApi();
                        datos.razonSocial = respuesta.razonSocial.ToString();
                        datos.Direccion = respuesta.direccion.ToString();
                    }

                }

                if (dniRuc.Length == 8)
                {
                    dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/dni/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImpvcmRhbmFuZ2Vscm9uZG9ucG96b0BnbWFpbC5jb20ifQ._sY7Mt0qrxCqH2uZH745-57025MYCXrnIZeg-whqgFs");

                    if (respuesta.success == true)
                    {
                        datos = new entApi();
                        datos.Nombre = respuesta.nombres.ToString();
                        datos.Apellido = respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();

                    }

                }
            } catch (Exception)
            {
                throw;
            }

            return datos;
        }
        #endregion
    }
}
