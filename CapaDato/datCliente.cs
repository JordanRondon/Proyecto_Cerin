using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
                    clie.RazonSocial = Convert.ToString(dr["razonSocial"]);
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
                cmd.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
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
                cmd.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
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

        public List<entCliente> listarClienteDni(string dni)
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarClientesDni", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", dni);
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

        public List<entCliente> listarClienteNombre(string nombre)
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarClientesNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
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

        public List<entCliente> listarClienteRuc(string ruc)
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_ListarClientesRuc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ruc", ruc);
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

        public bool ValidarDniUnica(string dni)
        {
            SqlCommand cmd = null;
            bool unica = false;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.GetInstancia.Conectar; // Singleton
                cn.Open();

                cmd = new SqlCommand("ValidarDNIUnico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlParameter returnValue = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                int resultado = (int)returnValue.Value;
                unica = (resultado == 1); // Si el resultado es 1, el DNI es único
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return unica;
        }

        public bool ValidarRucUnica(string dni)
        {
            SqlCommand cmd = null;
            bool unica = false;
            SqlConnection cn = null;

            try
            {
                cn = Conexion.GetInstancia.Conectar; // Singleton
                cn.Open();

                cmd = new SqlCommand("ValidarRUCUnico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlParameter returnValue = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                int resultado = (int)returnValue.Value;
                unica = (resultado == 1); // Si el resultado es 1, el DNI es único
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return unica;
        }



        #endregion Metodos
    }
}
