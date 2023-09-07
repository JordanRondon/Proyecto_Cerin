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

                cmd.Parameters.AddWithValue("@id_equipo", equipo_accesosorio.id_equipo);
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
        public List<entEquipo_Accesorio> ListAccsDeEquipo(int id_equipo) 
        {
            SqlCommand cmd = null;
            List<entEquipo_Accesorio> lista = new List<entEquipo_Accesorio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarAccesorioDeUnEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_equipo", id_equipo);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entEquipo_Accesorio equipoac = new entEquipo_Accesorio();

                    equipoac.id_equipo = id_equipo;
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
        #endregion Metodos
    }
}
