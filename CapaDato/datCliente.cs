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
    public class datCliente
    {
        #region Singleton
        private static readonly datCliente instancia = new datCliente();
        public static datCliente GetInstancia => instancia;
        #endregion

        #region Metodos
        public List<entCliente> listarCliente()
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entCliente clie = new entCliente();


                    clie.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    clie.Nombre = Convert.ToString(dr["nombre"]); 
                    clie.Apellido = Convert.ToString(dr["apellido"]); 
                    clie.Dni = Convert.ToString(dr["dni"]); 
                    clie.Ruc = Convert.ToString(dr["ruc"]); 
                    clie.Telefono = Convert.ToString(dr["telefono"]); 

                    lista.Add(clie);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public bool insertarCliente(entCliente cliente)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_InsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                cmd.Parameters.AddWithValue("@ruc", cliente.Ruc);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

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

        public bool editarCliente(entCliente cliente)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("sp_EditarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                cmd.Parameters.AddWithValue("@ruc", cliente.Ruc);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

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

        #endregion Metodos
    }
}
