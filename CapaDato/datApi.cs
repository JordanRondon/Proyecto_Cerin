﻿using CapaEntidad;
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
                    //"https://dniruc.apisperu.com/api/v1/dni/"12345678"?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNvcnBvcmFjaW9uY2VyaW5Ab3V0bG9vay5jb20ifQ.-8FHB4icMZTipZJq6GjEBdw-uXfuLbBMnbii3HZr2P0"
                    //"https://dniruc.apisperu.com/api/v1/ruc/"20131312955"?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNvcnBvcmFjaW9uY2VyaW5Ab3V0bG9vay5jb20ifQ.-8FHB4icMZTipZJq6GjEBdw-uXfuLbBMnbii3HZr2P0"

                    //dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/ruc/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImpvcmRhbmFuZ2Vscm9uZG9ucG96b0BnbWFpbC5jb20ifQ._sY7Mt0qrxCqH2uZH745-57025MYCXrnIZeg-whqgFs");
                    //---cuenta empresa---
                    //dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/ruc/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNvcnBvcmFjaW9uY2VyaW5Ab3V0bG9vay5jb20ifQ.-8FHB4icMZTipZJq6GjEBdw-uXfuLbBMnbii3HZr2P0");
                    //---cuenta prueba---
                    dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/ruc/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InlvYmVyLmxhMTRAZ21haWwuY29tIn0.Cton-xCh8ie6-OAktNyU8mLg3TpIIqEl9gShxZTeXG4");

                    if (respuesta.success != false)
                    {
                        datos = new entApi();
                        datos.razonSocial = respuesta.razonSocial.ToString();
                        datos.Direccion = respuesta.direccion.ToString();
                    }

                }

                if (dniRuc.Length == 8)
                {
                    //dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/dni/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImpvcmRhbmFuZ2Vscm9uZG9ucG96b0BnbWFpbC5jb20ifQ._sY7Mt0qrxCqH2uZH745-57025MYCXrnIZeg-whqgFs");
                    //---cuenta empresa---
                    //dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/dni/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNvcnBvcmFjaW9uY2VyaW5Ab3V0bG9vay5jb20ifQ.-8FHB4icMZTipZJq6GjEBdw-uXfuLbBMnbii3HZr2P0");
                    //---cuenta prueba---
                    dynamic respuesta = ApiDniRuc.GetInstancia.Get("https://dniruc.apisperu.com/api/v1/dni/" + dniRuc + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InlvYmVyLmxhMTRAZ21haWwuY29tIn0.Cton-xCh8ie6-OAktNyU8mLg3TpIIqEl9gShxZTeXG4");

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
