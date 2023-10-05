using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDato
{
    public class Conexion
    {
        private static readonly Conexion instancia = new Conexion();

        public static Conexion GetInstancia => instancia;

        public SqlConnection Conectar => new SqlConnection("Server=tcp:ceriningenieros.database.windows.net,1433;Initial Catalog=DBCERIN;Persist Security Info=False;User ID=CCIAdmin;Password=CCI&S%A-C%=2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //public SqlConnection Conectar => new SqlConnection("Data Source=DESKTOP-R3U5A28\\SQLEXPRESS;Initial Catalog=DBCERIN;" + "User Id=sa;Password=12345678;");

    }
}
