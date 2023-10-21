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
    public class datEquipo_Accesorio
    {
        #region Singleton
        private static readonly datEquipo_Accesorio instancia = new datEquipo_Accesorio();
        public static datEquipo_Accesorio GetInstancia => instancia;

        
        #endregion

        #region Metodos
        public bool insertarEquipoAccesorio(entEquipo_Accesorio equipo_accesosorio)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("InsertarEquipoAccesorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", equipo_accesosorio.SerieEquipo);
                cmd.Parameters.AddWithValue("@id_accesorio", equipo_accesosorio.id_accesorio);
                cmd.Parameters.AddWithValue("@cantidad", equipo_accesosorio.cantidad);

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
        public List<entEquipo_Accesorio> ListAccsDeEquipo(string serie) 
        {
            SqlCommand cmd = null;
            List<entEquipo_Accesorio> lista = new List<entEquipo_Accesorio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarAccesorioDeUnEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", serie);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo_Accesorio equipoac = new entEquipo_Accesorio();

                    equipoac.id_accesorio = Convert.ToInt16(dr["id_accesorio"]);
                    equipoac.cantidad = Convert.ToInt16(dr["cantidad"]);

                    lista.Add(equipoac);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;

        }
        public entEquipo_Accesorio BuscarEquipoAccesorio(string serie, int id_accesorio)
        {
            SqlCommand cmd = null;
            entEquipo_Accesorio detEquiAcc = null;
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_buscarDetEquiAcc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serie_equipo", serie);
                cmd.Parameters.AddWithValue("@id_accesorio", id_accesorio);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    detEquiAcc = new entEquipo_Accesorio();
                    detEquiAcc.id_accesorio = id_accesorio;
                    detEquiAcc.SerieEquipo = serie;
                    detEquiAcc.cantidad = Convert.ToInt16(dr["cantidad"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return detEquiAcc;
        }

        public bool EditarEquipoAccesorio(entEquipo_Accesorio det_equipo_Accesorio)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_EditarEquipoAccesorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", det_equipo_Accesorio.SerieEquipo);
                cmd.Parameters.AddWithValue("@id_accesorio", det_equipo_Accesorio.id_accesorio);
                cmd.Parameters.AddWithValue("@cantidad", det_equipo_Accesorio.cantidad);

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

        public List<entEquipo_Accesorio> Listar(string serie)
        {
            SqlCommand cmd = null;
            List<entEquipo_Accesorio> lista = new List<entEquipo_Accesorio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarEquipoAccesorio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serie_equipo", serie);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo_Accesorio det = new entEquipo_Accesorio();

                    det.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    det.id_accesorio = Convert.ToInt16(dr["id_accesorio"]);
                    det.cantidad = Convert.ToInt16(dr["cantidad"]);

                    lista.Add(det);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public bool EliminarDetalle(string serie, int id_accesorio)
        {
            SqlCommand cmd = null;
            bool elimina = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton
                cmd = new SqlCommand("sp_EliminarAccesorioDeEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", serie);
                cmd.Parameters.AddWithValue("@id_accesorio", id_accesorio);

                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    elimina = true;
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

            return elimina;
        }
        #endregion Metodos
    }
}
