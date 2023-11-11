using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CapaDato
{
    public class datDocumento
    {
        #region Singleton
        private static readonly datDocumento instancia = new datDocumento();
        public static datDocumento GetInstancia => instancia;
        #endregion

        public entDocumento BuscarDocumentoPorNombre(string nombre)
        {
            SqlCommand cmd = null;
            entDocumento ac = null; // Debes crear una instancia de la entidad entDocumento.
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("LeerDocumentoPorNombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre); // Corregir el nombre del parámetro.
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Asigna los valores del resultado al objeto entDocumento.
                    ac = new entDocumento
                    {
                        Id = Convert.ToInt16(dr["id"]),
                        Nombre = dr["nombre"].ToString(),
                        RealName = dr["realName"].ToString(),
                        Doc = (byte[])dr["doc"]
                    };
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
            return ac;
        }

        public entDocumento BuscarDocumentoPorId(int id)
        {
            SqlCommand cmd = null;
            entDocumento ac = null; // Debes crear una instancia de la entidad entDocumento.
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("LeerDocumentoPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id); // Corregir el nombre del parámetro.
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Asigna los valores del resultado al objeto entDocumento.
                    ac = new entDocumento
                    {
                        Id = Convert.ToInt16(dr["id"]),
                        Nombre = dr["nombre"].ToString(),
                        RealName = dr["realName"].ToString(),
                        Doc = (byte[])dr["doc"]
                    };
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null && cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
            return ac;
        }

        public string GuardarDocumentoTemporal(entDocumento doc)
        {
            string path  = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path + "temp\\";
            string fullFilePah = folder + doc.RealName;

            if(Directory.Exists(folder))
                Directory.Delete(folder, true);
            Directory.CreateDirectory(folder);
            File.WriteAllBytes(fullFilePah, doc.Doc);

            return fullFilePah;
        }

        public bool insertarDocumento(string nombre, string archivo, byte[] file)
        {
            SqlCommand cmd = null;
            bool inserta = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_insertarArchivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@archivo", archivo);
                cmd.Parameters.AddWithValue("@file", file);

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

        public bool editarDocumento(entDocumento documento)
        {
            SqlCommand cmd = null;
            bool edita = false;

            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar; //singleton

                cmd = new SqlCommand("sp_editarArchivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", documento.Id);
                cmd.Parameters.AddWithValue("@nombre", documento.Nombre);
                cmd.Parameters.AddWithValue("@archivo", documento.RealName);
                cmd.Parameters.AddWithValue("@file", documento.Doc);

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
            finally
            {
                cmd.Connection.Close();
            }

            return edita;
        }
    }
}
