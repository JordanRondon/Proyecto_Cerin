using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Text.RegularExpressions;

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

        public List<entMarca> listarMarcasPorCategoria(int idcategoria)
        {
            SqlCommand cmd = null;
            List<entMarca> lista = new List<entMarca>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarMarcaPorCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_categoria_marca", idcategoria);
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

        public int insertarMarca(entMarca marca)
        {
            SqlCommand cmd = null;
            int idGenerado = 0;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", marca.Nombre);

                SqlParameter paramIdGenerado = new SqlParameter("@id_marcagenerado", SqlDbType.Int);
                paramIdGenerado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramIdGenerado);

                cn.Open();

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    // Obtener el valor del parámetro de salida
                    idGenerado = Convert.ToInt32(paramIdGenerado.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { 
                cmd.Connection.Close(); 
            }

            return idGenerado;
        }

        public bool editarMarca(entMarca marca)
        {
            SqlCommand cmd = null;
            bool edita = false;
            
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_modificarMarca", cn);
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

        public bool deshabilitarMarca(entMarca marca)
        {
            SqlCommand cmd = null;
            bool seElimino = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_desHabilitarMarca", cn);

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

        public List<entMarcaCategoria> ListarDetalleMarca( int idMarca)
        {
            SqlCommand cmd = null;
            List<entMarcaCategoria> lista = new List<entMarcaCategoria>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarMarcaCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMarca", idMarca);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entMarcaCategoria marcaCat = new entMarcaCategoria();

                    marcaCat.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    marcaCat.id_categoria_equipo = Convert.ToInt32(dr["id_categoria_equipo"]);

                    lista.Add(marcaCat);
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

        public void InsertarMarcaCategoria(int id_marca, int id_categoria)
        {
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarMarcaCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_marca", id_marca);
                cmd.Parameters.AddWithValue("@id_categoria", id_categoria);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void eliminarMarcaCategoria(int idMarca)
        {
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_eliminarMarcaCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_marca", idMarca);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        
        #endregion
    }
}
