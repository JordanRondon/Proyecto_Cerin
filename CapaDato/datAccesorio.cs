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
        #endregion  Metodos

    }
}
