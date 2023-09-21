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
    public class datLogin
    {

        #region Singleton
        private static readonly datLogin instancia = new datLogin();
        public static datLogin GetInstancia => instancia;
        #endregion

        public bool ValidarUsuario(entEmpleado empleado)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_modificarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_empleado", empleado.IdEmpleado);
                cmd.Parameters.AddWithValue("@nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@dni", empleado.Dni);
                cmd.Parameters.AddWithValue("@direccion", empleado.Direccion);
                cmd.Parameters.AddWithValue("@correo", empleado.Correo);
                cmd.Parameters.AddWithValue("@telefono", empleado.Telefono);

                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    edita = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return edita;
        }

    }
}
