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
    public class datEquipo_Servicio
    {
        #region Singleton
        private static readonly datEquipo_Servicio instancia = new datEquipo_Servicio();
        public static datEquipo_Servicio GetInstancia => instancia;
        #endregion

        #region Metodos
        public bool insertarEquipoServicio(entEquipo_Servicio servicio_detalle)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("InsertarEquipoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", servicio_detalle.serie_equipo);
                cmd.Parameters.AddWithValue("@id_servicio", servicio_detalle.IdServicio);
                cmd.Parameters.AddWithValue("@observaciones_preliminares", servicio_detalle.Observaciones_preliminares);
                cmd.Parameters.AddWithValue("@observaciones_finales", servicio_detalle.observaciones_finales);

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

        public List<entEquipo> listarEquiposDeUnServicio(int id_servicio)
        {
            SqlCommand cmd = null;
            List<entEquipo> lista = new List<entEquipo>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarEquipoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_servicio", id_servicio);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo equipo = new entEquipo();

                    equipo.SerieEquipo = Convert.ToString(dr["serie_equipo"]);
                    equipo.id_modelo = Convert.ToInt16(dr["id_modelo"]);
                    equipo.Estado = Convert.ToChar(dr["estado"]);
                    equipo.IdMarca = Convert.ToInt32(dr["id_Marca"]);
                    equipo.otrosaccesorios = Convert.ToString(dr["otros_accesorios"]);
                    equipo.id_categoria = Convert.ToInt32(dr["id_categoria_equipo"]);

                    lista.Add(equipo);
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

        public bool editarEquipoServicio(entEquipo_Servicio equipoServicio)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_editarEquipoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", equipoServicio.serie_equipo);
                cmd.Parameters.AddWithValue("@id_servicio", equipoServicio.IdServicio);
                cmd.Parameters.AddWithValue("@Observaciones_preliminares", equipoServicio.Observaciones_preliminares);
                cmd.Parameters.AddWithValue("@observaciones_finales", equipoServicio.observaciones_finales);

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

        public entEquipo_Servicio BuscarEquipoServicioId(string serieEquipo, int id_servicio)
        {
            SqlCommand cmd = null;
            entEquipo_Servicio equipoServicio = new entEquipo_Servicio();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("sp_BuscarEquipoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serie_equipo", serieEquipo);
                cmd.Parameters.AddWithValue("@id_servicio", id_servicio);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    equipoServicio.serie_equipo = Convert.ToString(dr["serie_equipo"]);
                    equipoServicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    equipoServicio.Observaciones_preliminares = Convert.ToString(dr["Observaciones_preliminares"]);
                    equipoServicio.observaciones_finales = Convert.ToString(dr["observaciones_finales"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return equipoServicio;
        }
        #endregion Metodos
    }
}
