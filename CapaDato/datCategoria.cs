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
    public class datCategoria
    {
        #region Singleton
        private static readonly datCategoria instancia = new datCategoria();
        public static datCategoria GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entCategoria> listarCategoria()
        {
            SqlCommand cmd = null;
            List<entCategoria> lista = new List<entCategoria>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entCategoria c = new entCategoria();

                    c.id_categoria_equipo= Convert.ToInt32(dr["id_categoria_equipo"]);
                    c.Nombre = Convert.ToString(dr["nombre"]);

                    lista.Add(c);
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
        public entCategoria BuscarCategoriaPorNombre(string nombre)
        {
            SqlCommand cmd = null;
            entCategoria c = new entCategoria();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("BuscarCategoriaPorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.id_categoria_equipo = Convert.ToInt32(dr["id_categoria_equipo"]);
                    c.Nombre = Convert.ToString(dr["nombre"]);
                    break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return c;
        }

        public entCategoria buscarCategoriaId(int id)
        {
            SqlCommand cmd = null;
            entCategoria cat = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("ps_BuscarCategoriaId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_categoria_equipo", id);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cat = new entCategoria();
                    cat.id_categoria_equipo = Convert.ToInt32(dr["id_categoria_equipo"]);
                    cat.Nombre = Convert.ToString(dr["nombre"]);
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

            return cat;
        }
        #endregion Metodos
    }
}
