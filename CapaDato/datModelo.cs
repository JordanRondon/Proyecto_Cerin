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
    public class datModelo
    {
        #region Singleton
        private static readonly datModelo instancia = new datModelo();
        public static datModelo GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entModelo> listarModelo()
        {
            SqlCommand cmd = null;
            List<entModelo> lista = new List<entModelo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entModelo modelo = new entModelo();

                    modelo.id_modelo = Convert.ToInt32(dr["id_modelo"]);
                    modelo.nombre = Convert.ToString(dr["nombre"]);
                    modelo.estado = Convert.ToChar(dr["estado"]);

                    lista.Add(modelo);
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

            return lista;
        }

        public bool insertarModelo(entModelo modelo)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", modelo.nombre);

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

        public bool editarModelo(entModelo modelo)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_modificarModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_modelo", modelo.id_modelo);
                cmd.Parameters.AddWithValue("@nombre", modelo.nombre);
                cmd.Parameters.AddWithValue("@estado", modelo.estado);

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

        public entModelo BuscarModeloPorId(int idModelo)
        {
            SqlCommand cmd = null;
            entModelo m = new entModelo();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("spbuscarModeloPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_modelo", idModelo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    m.id_modelo = Convert.ToInt32(dr["id_modelo"]);
                    m.nombre = Convert.ToString(dr["nombre"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return m;
        }
    }
    #endregion Metodos
}
