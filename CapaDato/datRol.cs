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
    public class datRol
    {
        #region Singleton
        private static readonly datRol instancia = new datRol();
        public static datRol GetInstancia => instancia;
        #endregion

        #region Métodos
        public List<entRol> listarRol()
        {
            SqlCommand cmd = null;
            List<entRol> lista = new List<entRol>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_listarRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entRol rol = new entRol();

                    rol.id_rol = Convert.ToInt32(dr["id_rol"]);
                    rol.nombre = Convert.ToString(dr["nombre_rol"]);

                    lista.Add(rol);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public entRol buscarRolId(int id_rol)
        {
            SqlCommand cmd = null;
            entRol rol = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("ps_buscarRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_rol", id_rol);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    rol = new entRol();

                    rol.id_rol = Convert.ToInt32(dr["id_rol"]);
                    rol.nombre = Convert.ToString(dr["nombre_rol"]);
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

            return rol;
        }
        #endregion
    }
}
