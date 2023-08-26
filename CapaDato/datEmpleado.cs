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
    public class datEmpleado
    {
        #region Singleton
        private static readonly datEmpleado instancia = new datEmpleado();
        public static datEmpleado GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entEmpleado> listarEmpleado()
        {
            SqlCommand cmd = null;
            List<entEmpleado> lista = new List<entEmpleado>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEmpleado empleado = new entEmpleado();

                    empleado.IdEmpleado = Convert.ToInt32(dr["id_Marca"]);
                    empleado.Nombre = Convert.ToString(dr["nombre"]);
                    empleado.Apellido = Convert.ToString(dr["apellido"]);
                    empleado.Dni = Convert.ToInt32(dr["dni"]);
                    empleado.Direccion = Convert.ToString(dr["direccion"]);
                    empleado.Correo = Convert.ToString(dr["correo"]);
                    empleado.Telefono = Convert.ToInt32(dr["telefono"]);

                    lista.Add(empleado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }
        #endregion
    }
}
