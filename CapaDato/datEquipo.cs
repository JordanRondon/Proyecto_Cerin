using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaDato
{
    public class datEquipo
    {
        #region Singleton
        private static readonly datEquipo instancia = new datEquipo();
        public static datEquipo GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entEquipo> listarEquipo()
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarEquipoAlquiler", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.IdEquipo = Convert.ToInt32(dr["id_equipo"]);
                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.Modelo = Convert.ToString(dr["modelo"]);
                    equipo.Observaciones = Convert.ToString(dr["observaciones"]);
                    equipo.Recomendaciones = Convert.ToString(dr["recomendaciones"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);

                    lista.Add(equipo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public bool insertarEquipo(entEquipo equipo)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", equipo.SerieEquipo);
                cmd.Parameters.AddWithValue("@modelo", equipo.Modelo);
                cmd.Parameters.AddWithValue("@observaciones", equipo.Observaciones);
                cmd.Parameters.AddWithValue("@recomendaciones", equipo.Recomendaciones);
                cmd.Parameters.AddWithValue("@estado", equipo.Estado);
                cmd.Parameters.AddWithValue("@id_tipo", equipo.IdTipo);
                cmd.Parameters.AddWithValue("@id_Marca", equipo.IdMarca);

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

        public bool editarEquipo(entEquipo equipo)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_modificarEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_equipo", equipo.IdEquipo);
                cmd.Parameters.AddWithValue("@serie_equipo", equipo.SerieEquipo);
                cmd.Parameters.AddWithValue("@modelo", equipo.Modelo);
                cmd.Parameters.AddWithValue("@observaciones", equipo.Observaciones);
                cmd.Parameters.AddWithValue("@recomendaciones", equipo.Recomendaciones);
                cmd.Parameters.AddWithValue("@estado", equipo.Estado);
                cmd.Parameters.AddWithValue("@id_tipo", equipo.IdTipo);
                cmd.Parameters.AddWithValue("@id_Marca", equipo.IdMarca);

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

        public bool deshabilitarEquipo(entEquipo equipo)
        {
            SqlCommand cmd = null;
            bool seElimino = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_deshabilitarEquipo", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_equipo", equipo.IdEquipo);

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

        public List<entEquipo> listarEquipoModelo(string modelo)
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listEquipAlquModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@modelo", modelo);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.IdEquipo = Convert.ToInt32(dr["id_equipo"]);
                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.Modelo = Convert.ToString(dr["modelo"]);
                    equipo.Observaciones = Convert.ToString(dr["observaciones"]);
                    equipo.Recomendaciones = Convert.ToString(dr["recomendaciones"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);

                    lista.Add(equipo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public List<entEquipo> listarEquipoSerie(string serie)
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listEquipAlquSerie", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serie", serie);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.IdEquipo = Convert.ToInt32(dr["id_equipo"]);
                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.Modelo = Convert.ToString(dr["modelo"]);
                    equipo.Observaciones = Convert.ToString(dr["observaciones"]);
                    equipo.Recomendaciones = Convert.ToString(dr["recomendaciones"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);

                    lista.Add(equipo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public List<entEquipo> listarEquipoMarca( string marca)
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listEquipAlquMarca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marca", marca);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.IdEquipo = Convert.ToInt32(dr["id_equipo"]);
                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.Modelo = Convert.ToString(dr["modelo"]);
                    equipo.Observaciones = Convert.ToString(dr["observaciones"]);
                    equipo.Recomendaciones = Convert.ToString(dr["recomendaciones"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);

                    lista.Add(equipo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }
        #endregion
    }
}
