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
        public List<entModelo> listarModelo(int id_marca, int id_categoria)
        {
            SqlCommand cmd = null;
            List<entModelo> lista = new List<entModelo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_marca", id_marca);
                cmd.Parameters.AddWithValue("@id_categoria_equipo", id_categoria);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entModelo modelo = new entModelo();

                    modelo.id_modelo = Convert.ToInt32(dr["id_modelo"]);
                    Console.WriteLine(modelo.id_modelo);
                    modelo.nombre = Convert.ToString(dr["nombre"]);
                    modelo.estado = Convert.ToChar(dr["estado"]);
                    modelo.IdMarca = new entMarca();
                    modelo.IdMarca.IdMarca = Convert.ToInt16(dr["id_Marca"]);
                    modelo.IdCategoriaEquipo = new entCategoria();
                    modelo.IdCategoriaEquipo.id_categoria_equipo = Convert.ToInt16(dr["id_categoria_equipo"]);

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

        public List<entModelo> listarTodosModelo()
        {
            SqlCommand cmd = null;
            List<entModelo> lista = new List<entModelo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarTodosModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entModelo modelo = new entModelo();

                    modelo.id_modelo = Convert.ToInt32(dr["id_modelo"]);
                    modelo.nombre = Convert.ToString(dr["nameModelo"]);
                    modelo.estado = Convert.ToChar(dr["estado"]);
                    modelo.IdMarca = new entMarca();
                    modelo.IdMarca.IdMarca = Convert.ToInt16(dr["id_Marca"]);
                    modelo.IdMarca.Nombre = Convert.ToString(dr["nameMarca"]);
                    modelo.IdCategoriaEquipo = new entCategoria();
                    modelo.IdCategoriaEquipo.id_categoria_equipo = Convert.ToInt16(dr["id_categoria_equipo"]);
                    modelo.IdCategoriaEquipo.Nombre = Convert.ToString(dr["nameCategoria"]);

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
                cmd.Parameters.AddWithValue("@id_marca", modelo.IdMarca.IdMarca);
                cmd.Parameters.AddWithValue("@id_categoria_equipo", modelo.IdCategoriaEquipo.id_categoria_equipo);
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
                cmd.Parameters.AddWithValue("@id_marca", modelo.IdMarca.IdMarca);
                cmd.Parameters.AddWithValue("@id_categoria_equipo", modelo.IdCategoriaEquipo.id_categoria_equipo);

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
                    m.IdMarca = new entMarca();
                    m.IdMarca.IdMarca = Convert.ToInt16(dr["id_Marca"]);
                    m.IdCategoriaEquipo = new entCategoria();
                    m.IdCategoriaEquipo.id_categoria_equipo = Convert.ToInt16(dr["id_categoria_equipo"]);
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
