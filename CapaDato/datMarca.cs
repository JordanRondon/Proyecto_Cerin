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
    public class datMarca
    {
        #region Singleton
        private static readonly datMarca instancia = new datMarca();
        public static datMarca GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entMarca> listarMarcas()
        {
            SqlCommand cmd = null;
            List<entMarca> lista = new List<entMarca>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton
                
                cmd = new SqlCommand("sp_listarMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entMarca marca = new entMarca();

                    marca.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    marca.Nombre = Convert.ToString(dr["nombre"]);
                    
                    lista.Add(marca);
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

        public bool insertarMarca(entMarca marca)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", marca.Nombre);

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
            finally { 
                cmd.Connection.Close(); 
            }

            return inserta;
        }

        public bool editarMarca(entMarca marca)
        {
            SqlCommand cmd = null;
            bool edita = false;
            
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_modificartarMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Marca", marca.IdMarca);
                cmd.Parameters.AddWithValue("@nombre", marca.Nombre);
                
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

        public bool eliminarMarca(entMarca marca)
        {
            SqlCommand cmd = null;
            bool seElimino = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_eliminarMarca", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_marca", marca.IdMarca);
                
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

        public entMarca BuscarMarcaPorId(int idMarca)
        {
            SqlCommand cmd = null;
            entMarca ma = new entMarca();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("spbuscarMarcaPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Marca", idMarca);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ma.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    ma.Nombre = Convert.ToString(dr["nombre"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return ma;
        }
        #endregion
    }
}
