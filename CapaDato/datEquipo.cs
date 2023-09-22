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
        public List<entEquipo> listarEquipoAlquiler()
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

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);

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
        public List<entEquipo> listarEquipoExternos()
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarEquipoExternosDisp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);

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

        public List<entEquipo> listarEquipoDisponible()
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_listarEquipoAlquilerDisponibles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);

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

        public string insertarEquipo(entEquipo equipo)
        {
            SqlCommand cmd = null;
            string serie = "";

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", equipo.SerieEquipo);
                cmd.Parameters.AddWithValue("@estado", equipo.Estado);
                cmd.Parameters.AddWithValue("@id_modelo", equipo.id_modelo);
                cmd.Parameters.AddWithValue("@id_tipo", equipo.IdTipo);
                cmd.Parameters.AddWithValue("@id_Marca", equipo.IdMarca);
                cmd.Parameters.AddWithValue("@id_categoria_equipo", equipo.id_categoria);
                cmd.Parameters.AddWithValue("@otros_accesorios", equipo.otrosaccesorios);


                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0 )
                {
                    serie = equipo.SerieEquipo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return serie;
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

                cmd.Parameters.AddWithValue("@serie_equipo", equipo.SerieEquipo);
                cmd.Parameters.AddWithValue("@id_modelo", equipo.id_modelo);
                cmd.Parameters.AddWithValue("@estado", equipo.Estado);
                cmd.Parameters.AddWithValue("@id_tipo", equipo.IdTipo);
                cmd.Parameters.AddWithValue("@id_Marca", equipo.IdMarca);
                cmd.Parameters.AddWithValue("@id_categoria_equipo", equipo.id_categoria);
                cmd.Parameters.AddWithValue("@otros_accesorios", equipo.otrosaccesorios);

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
                cmd.Parameters.AddWithValue("@serie_equipo", equipo.SerieEquipo);

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

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);

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

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);

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

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);

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

        public entEquipo buscarEquipo(string serie_equipo)
        {
            SqlCommand cmd = null;
            entEquipo equipo = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("sp_BuscarEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", serie_equipo);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    equipo = new entEquipo();

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdTipo = Convert.ToInt32(dr["id_tipo"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);
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

            return equipo;
        }
        #endregion
    }
}
