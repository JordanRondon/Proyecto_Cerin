using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.RecursosAdicionales.Clases
{
    public static class Mensajes
    {
        public static void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MensajeGeneral(string mensaje)
        {
            MessageBox.Show(mensaje,"Error",MessageBoxButtons.OK);
        }
    }
}
