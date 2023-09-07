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
    public class datAccesorio
    {
        #region Singleton
        private static readonly datAccesorio instancia = new datAccesorio();
        public static datAccesorio GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entAccesorio> listarAccesorio()
        {
            SqlCommand cmd = null;
            List<entAccesorio> lista = new List<entAccesorio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ListarAccesorios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entAccesorio ac = new entAccesorio();

                    ac.IdAccesorio = Convert.ToInt32(dr["id_accesorio"]);
                    ac.Nombre = Convert.ToString(dr["nombre"]);

                    lista.Add(ac);
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
        public entAccesorio BuscarAccesorioNombre(string nombre)
        {
            SqlCommand cmd = null;
            entAccesorio ac = new entAccesorio();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_buscarAccesorioPorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ac.IdAccesorio = Convert.ToInt32(dr["id_accesorio"]);
                    ac.Nombre = Convert.ToString(dr["nombre"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return ac;
        }

        public entAccesorio BuscarAccesorioId(int id)
        {
            SqlCommand cmd = null;
            entAccesorio ac = new entAccesorio();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_buscarAccesorioPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_accesorio", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ac.IdAccesorio = Convert.ToInt32(dr["id_accesorio"]);
                    ac.Nombre = Convert.ToString(dr["nombre"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return ac;
        }
        #endregion  Metodos

    }
}
