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
    public class datEquipo_Accesorio
    {
        #region Singleton
        private static readonly datEquipo_Accesorio instancia = new datEquipo_Accesorio();
        public static datEquipo_Accesorio GetInstancia => instancia;
        #endregion

        #region Metodos
        public bool insertarEquipoAccesorio(entEquipo_Accesorio equipo_accesosorio)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("InsertarEquipoAccesorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_equipo", equipo_accesosorio.id_equipo);
                cmd.Parameters.AddWithValue("@id_accesorio", equipo_accesosorio.id_accesorio);
                cmd.Parameters.AddWithValue("@cantidad", equipo_accesosorio.cantidad);

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
