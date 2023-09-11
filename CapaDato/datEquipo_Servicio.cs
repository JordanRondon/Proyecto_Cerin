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
        #endregion Metodos
    }
}
