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

        public entDocumento BuscarDocumentoPorId(int id)
        {
            SqlCommand cmd = null;
            entDocumento ac = null; // Debes crear una instancia de la entidad entDocumento.
            try
            {
                SqlConnection cn = Conexion.GetInstancia.Conectar;
                cmd = new SqlCommand("LeerDocumentoPorID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocumentoID", id); // Corregir el nombre del parámetro.
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Asigna los valores del resultado al objeto entDocumento.
                    ac = new entDocumento
                    {
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
    }
}
