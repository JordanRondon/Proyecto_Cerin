using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDato
{
    public class datUser
    {
        #region Singleton
        private static readonly datUser instancia = new datUser();
        public static datUser GetInstancia => instancia;
        #endregion

        #region Métodos
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

        public List<entUsuario> listarUsuarios()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_listarUsuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entUsuario usuario = new entUsuario();

                    usuario.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                    usuario.userName = Convert.ToString(dr["nombre_usuario"]);
                    usuario.password = Convert.ToString(dr["contraseña"]);
                    usuario.id_rol = Convert.ToInt32(dr["id_rol"]);
                    usuario.estado = Convert.ToChar(dr["estado"]);
                    usuario.id_empleado = Convert.ToInt32(dr["id_empleado"]);

                    lista.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public entUsuario buscarUsuario(int id_empleado)
        {
            SqlCommand cmd = null;
            entUsuario usuario = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("ps_obtenerUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_empleado", id_empleado);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usuario = new entUsuario();

                    usuario.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                    usuario.userName = Convert.ToString(dr["nombre_usuario"]);
                    usuario.password = Convert.ToString(dr["contraseña"]);
                    usuario.id_rol = Convert.ToInt32(dr["id_rol"]);
                    usuario.estado = Convert.ToChar(dr["estado"]);
                    usuario.id_empleado = Convert.ToInt32(dr["id_empleado"]);
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

            return usuario;
        }

        public bool insertarUsuario(entUsuario usuario)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_insertarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.userName);
                cmd.Parameters.AddWithValue("@contraseña", usuario.password);
                cmd.Parameters.AddWithValue("@id_rol", usuario.id_rol);
                cmd.Parameters.AddWithValue("@id_empleado", usuario.id_empleado);

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

        public bool editarUsuario(entUsuario usuario)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("ps_modificarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);
                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.userName);
                cmd.Parameters.AddWithValue("@contraseña", usuario.password);
                cmd.Parameters.AddWithValue("@id_rol", usuario.id_rol);

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

        public bool deshabilitarUsuario(entUsuario usuario)
        {
            SqlCommand cmd = null;
            bool seElimino = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("ps_deshabilitarUsuario", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", usuario.id_usuario);

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

        #endregion Métodos
    }
}
