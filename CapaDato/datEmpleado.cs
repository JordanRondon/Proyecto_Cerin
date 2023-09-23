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

                    empleado.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    empleado.Nombre = Convert.ToString(dr["nombre"]);
                    empleado.Apellido = Convert.ToString(dr["apellido"]);
                    empleado.Dni = Convert.ToString(dr["dni"]);
                    empleado.Direccion = Convert.ToString(dr["direccion"]);
                    empleado.Correo = Convert.ToString(dr["correo"]);
                    empleado.Telefono = Convert.ToString(dr["telefono"]);

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

        public bool insertarEmpleado(entEmpleado empleado)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

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
                    inserta = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return inserta;
        }

        public bool editarEmpleado(entEmpleado empleado)
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

        public bool deshabilitarEmpleado(entEmpleado empleado)
        {
            SqlCommand cmd = null;
            bool seElimino = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_desHabilitarEmpleado", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_empleado", empleado.IdEmpleado);

                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    seElimino = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return seElimino;
        }
        public entEmpleado BuscarEmpleadoId(int id)
        {
            SqlCommand cmd = null;
            entEmpleado empleado = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("sp_BuscarEmpleadoPorID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_empleado", id);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    empleado = new entEmpleado();

                    empleado.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    empleado.Apellido = Convert.ToString(dr["nombre"]); ;
                    empleado.Nombre = Convert.ToString(dr["apellido"]); ;
                    empleado.Dni = Convert.ToString(dr["dni"]); ;
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
                    cmd.Dispose();
                }
            }

            return empleado;
        }

        public entEmpleado BuscarEmpleadoDNI(string dni)
        {
            SqlCommand cmd = null;
            entEmpleado empleado = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("sp_BuscarEmpleadoPorDNI", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dni", dni);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    empleado = new entEmpleado();

                    empleado.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    empleado.Apellido = Convert.ToString(dr["nombre"]); ;
                    empleado.Nombre = Convert.ToString(dr["apellido"]); ;
                    empleado.Dni = Convert.ToString(dr["dni"]);
                    empleado.Direccion = Convert.ToString(dr["direccion"]);
                    empleado.Correo = Convert.ToString(dr["correo"]);
                    empleado.Telefono = Convert.ToString(dr["telefono"]);
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
                    cmd.Dispose();
                }
            }

            return empleado;
        }

        #endregion
    }
}
