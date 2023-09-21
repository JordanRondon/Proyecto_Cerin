using Cerin_Ingenieros.Consultas;
using Cerin_Ingenieros.Mantenedor;
using Cerin_Ingenieros.Servicios;
using Cerin_Ingenieros.Servicios.ClienteOpciones;
using Cerin_Ingenieros.Servicios.ViewCertificado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new preRegistrarCliente());
        }
    }
}
