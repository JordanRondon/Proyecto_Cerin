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
    public class datTipo
    {
        #region Singleton
        private static readonly datTipo instancia = new datTipo();
        public static datTipo GetInstancia => instancia;
        #endregion

        #region Metodos

        public entTipoServicio BuscarTipoPorNombre(string nombre)
        {
            SqlCommand cmd = null;
            entTipoServicio t = new entTipoServicio();
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("BuscarTipoPorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    t.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    t.Nombre = Convert.ToString(dr["nombre"]);
                    break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return t;
        }

        public entTipoServicio buscarTipoServicioId(int id_TipoServicio)
        {
            SqlCommand cmd = null;
            entTipoServicio tipoServicio = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("ps_BuscarTipoServicioId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_tipo_servicio", id_TipoServicio);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    tipoServicio = new entTipoServicio();
                    tipoServicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    tipoServicio.Nombre = Convert.ToString(dr["nombre"]);
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

            return tipoServicio;
        }
        #endregion Metodos
    }
}
