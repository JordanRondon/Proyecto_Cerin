using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapaDato
{
    public class datServicio
    {
        #region Singleton
        private static readonly datServicio instancia = new datServicio();
        public static datServicio GetInstancia => instancia;
        #endregion

        #region Metodos

        public int insertarServicio(entServicio servicio)
        {
            SqlCommand cmd = null;
            int nuevoID = 0;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("InsertarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha_registro", servicio.FechaRegistro);
                cmd.Parameters.AddWithValue("@id_tipo_servicio", servicio.IdTipoServicio);
                cmd.Parameters.AddWithValue("@id_cliente", servicio.IdCliente);
                cmd.Parameters.AddWithValue("@id_empleado", servicio.IdEmpleado);
                cmd.Parameters.AddWithValue("@estado", servicio.estado);
                cmd.Parameters.AddWithValue("@estadoPago", servicio.estadoPago);
                cmd.Parameters.AddWithValue("@estadoStiker", servicio.estadoStikers);
                cmd.Parameters.AddWithValue("@estadoLab", servicio.estadoLaboratorio);

                SqlParameter outputParameter = new SqlParameter("@NuevoID", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                cn.Open();

                int i = cmd.ExecuteNonQuery();

                // Verificar si se insertó correctamente y si se obtuvo un nuevo ID
                if (i > 0 && outputParameter.Value != DBNull.Value)
                {
                    nuevoID = Convert.ToInt32(outputParameter.Value);
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

            return nuevoID;
        }

        public bool ActualizarEntregaServicio(entServicio servicio)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;

                cmd = new SqlCommand("ps_ActualizarEntrega", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_servicio", servicio.IdServicio);
                cmd.Parameters.AddWithValue("@fecha_entrega", servicio.FechaEntrega);

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

        public entServicio buscarServicio(int id_servicio)
        {
            SqlCommand cmd = null;
            entServicio servicio = null;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; // Singleton

                cmd = new SqlCommand("ps_ObtenerServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_servicio", id_servicio);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    servicio = new entServicio();
                    servicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    servicio.FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]);
                    if (dr["fecha_entrega"] != DBNull.Value)
                    {
                        servicio.FechaEntrega = Convert.ToDateTime(dr["fecha_entrega"]);
                    }
                    servicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    servicio.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    servicio.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    servicio.estado = Convert.ToChar(dr["estado"]);
                    servicio.estadoStikers = Convert.ToChar(dr["estadoStikers"]);
                    servicio.estadoPago = Convert.ToChar(dr["estadoPago"]);
                    servicio.estadoLaboratorio = Convert.ToChar(dr["estadoLaboratorio"]);
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

            return servicio;
        }

        public bool ActualizarEstadoEquipo(entServicio servicio)
        {
            SqlCommand cmd = null;
            bool seElimino = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("ps_CambiarEstadoEquiposServicio", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_servicio", servicio.IdServicio);

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

        public List<entServicio> listarServicioCliente(int id_cliente)
        {
            SqlCommand cmd = null;
            List<entServicio> lista = new List<entServicio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_listarServiciosCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entServicio servicio = new entServicio();

                    servicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    if (dr["fecha_registro"] != DBNull.Value)
                        servicio.FechaRegistro = Convert.ToDateTime((dr["fecha_registro"]));
                    if (dr["fecha_entrega"] != DBNull.Value)
                        servicio.FechaEntrega = Convert.ToDateTime((dr["fecha_entrega"]));
                    servicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    servicio.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    servicio.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    servicio.estado = Convert.ToChar(dr["estado"]);

                    lista.Add(servicio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public List<entServicio> listarServicioEquipo(string serie_equipo)
        {
            SqlCommand cmd = null;
            List<entServicio> lista = new List<entServicio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_ListarServicioEquipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@serie_equipo", serie_equipo);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entServicio servicio = new entServicio();

                    servicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    if (dr["fecha_registro"] != DBNull.Value)
                        servicio.FechaRegistro = Convert.ToDateTime((dr["fecha_registro"]));
                    if (dr["fecha_entrega"] != DBNull.Value)
                        servicio.FechaEntrega = Convert.ToDateTime((dr["fecha_entrega"]));
                    servicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    servicio.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    servicio.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    servicio.estado = Convert.ToChar(dr["estado"]);

                    lista.Add(servicio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public List<entServicio> listarServicios()
        {
            SqlCommand cmd = null;
            List<entServicio> lista = new List<entServicio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_ListarServicios", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entServicio servicio = new entServicio();

                    servicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    if (dr["fecha_registro"] != DBNull.Value)
                        servicio.FechaRegistro = Convert.ToDateTime((dr["fecha_registro"]));
                    if (dr["fecha_entrega"] != DBNull.Value)
                        servicio.FechaEntrega = Convert.ToDateTime((dr["fecha_entrega"]));
                    servicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    servicio.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    servicio.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    servicio.estado = Convert.ToChar(dr["estado"]);
                    servicio.estadoStikers = Convert.ToChar(dr["estadoStikers"]);
                    servicio.estadoPago = Convert.ToChar(dr["estadoPago"]);
                    servicio.estadoLaboratorio = Convert.ToChar(dr["estadoLaboratorio"]);

                    lista.Add(servicio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public List<entServicio> listarServiciosPendientes()
        {
            SqlCommand cmd = null;
            List<entServicio> lista = new List<entServicio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_ListarServiciosPendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entServicio servicio = new entServicio();

                    servicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    if (dr["fecha_registro"] != DBNull.Value)
                        servicio.FechaRegistro = Convert.ToDateTime((dr["fecha_registro"]));
                    if (dr["fecha_entrega"] != DBNull.Value)
                        servicio.FechaEntrega = Convert.ToDateTime((dr["fecha_entrega"]));
                    servicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    servicio.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    servicio.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    servicio.estado = Convert.ToChar(dr["estado"]);
                    servicio.estadoStikers = Convert.ToChar(dr["estadoStikers"]);
                    servicio.estadoPago = Convert.ToChar(dr["estadoPago"]);
                    servicio.estadoLaboratorio = Convert.ToChar(dr["estadoLaboratorio"]);

                    lista.Add(servicio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally { cmd.Connection.Close(); }

            return lista;
        }

        public List<entServicio> listarServiciosTerminados()
        {
            SqlCommand cmd = null;
            List<entServicio> lista = new List<entServicio>();

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("ps_ListarServiciosTerminados", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entServicio servicio = new entServicio();

                    servicio.IdServicio = Convert.ToInt32(dr["id_servicio"]);
                    if (dr["fecha_registro"] != DBNull.Value)
                        servicio.FechaRegistro = Convert.ToDateTime((dr["fecha_registro"]));
                    if (dr["fecha_entrega"] != DBNull.Value)
                        servicio.FechaEntrega = Convert.ToDateTime((dr["fecha_entrega"]));
                    servicio.IdTipoServicio = Convert.ToInt32(dr["id_tipo_servicio"]);
                    servicio.IdCliente = Convert.ToInt32(dr["id_cliente"]);
                    servicio.IdEmpleado = Convert.ToInt32(dr["id_empleado"]);
                    servicio.estado = Convert.ToChar(dr["estado"]);
                    servicio.estadoStikers = Convert.ToChar(dr["estadoStikers"]);
                    servicio.estadoPago = Convert.ToChar(dr["estadoPago"]);
                    servicio.estadoLaboratorio = Convert.ToChar(dr["estadoLaboratorio"]);

                    lista.Add(servicio);
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
