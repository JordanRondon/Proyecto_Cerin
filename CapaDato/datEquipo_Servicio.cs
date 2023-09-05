using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class datEquipo_Servicio
    {
        #region Singleton
        private static readonly datEquipo_Servicio instancia = new datEquipo_Servicio();
        public static datEquipo_Servicio GetInstancia => instancia;
        #endregion

        #region Metodos
        public bool insertarEquipoServicio(entEquipo_Servicio servicio_detalle)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("InsertarEquipoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_equipo", servicio_detalle.IdEquipo);
                cmd.Parameters.AddWithValue("@id_servicio", servicio_detalle.IdServicio);

                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return inserta;
        }
        #endregion Metodos
    }
}
