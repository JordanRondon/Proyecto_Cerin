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
    public class datServicio
    {
        #region Singleton
        private static readonly datServicio instancia = new datServicio();
        public static datServicio GetInstancia => instancia;
        #endregion

        #region Metodos

        public int insertarServicio(entServicio servicio)
        {
            SqlCommand cmd = null;
            int nuevoID = 0;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("InsertarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha_registro", servicio.FechaRegistro);
                cmd.Parameters.AddWithValue("@id_tipo", servicio.IdTipo);
                cmd.Parameters.AddWithValue("@id_cliente", servicio.IdCliente);
                cmd.Parameters.AddWithValue("@id_empleado", servicio.IdEmpleado);

                SqlParameter outputParameter = new SqlParameter("@NuevoID", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                cn.Open();

                int i = cmd.ExecuteNonQuery();

                // Verificar si se insertó correctamente y si se obtuvo un nuevo ID
                if (i > 0 && outputParameter.Value != DBNull.Value)
                {
                    nuevoID = Convert.ToInt32(outputParameter.Value);
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

            return nuevoID;
        }


        #endregion Metodos

    }
}
