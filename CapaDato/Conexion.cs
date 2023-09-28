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

        public SqlConnection Conectar => new SqlConnection("Data Source=.;Initial Catalog=DBCERIN;" + "Integrated Security=true;");
        //public SqlConnection Conectar => new SqlConnection("Data Source=DESKTOP-R3U5A28\\SQLEXPRESS;Initial Catalog=DBCERIN;" + "User Id=sa;Password=12345678;");

    }
}
