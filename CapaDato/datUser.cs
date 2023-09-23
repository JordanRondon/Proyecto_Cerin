using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class datUser
    {
        #region Singleton
        private static readonly datUser instancia = new datUser();
        public static datUser GetInstancia => instancia;
        #endregion

        public int ValidarSesion(string user, string password)
        {
            SqlCommand cmd = null;
            int estado = 0;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("ValidarInicioSesion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre_usuario", user);
                cmd.Parameters.AddWithValue("@contraseña", password);

                SqlParameter outputParameter = new SqlParameter("@InicioSesionValido", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                cn.Open();

                cmd.ExecuteNonQuery();

                if (outputParameter.Value != DBNull.Value)
                {
                    estado = Convert.ToInt32(outputParameter.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                }
            }

            return estado;
        }

    }
}
