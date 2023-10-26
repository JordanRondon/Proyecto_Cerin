using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.RecursosAdicionales.Clases
{
    public static class configColores
    {
        public static Color btnActivo = Color.FromArgb(255, 128, 0); 
        public static Color btDesactivado = Color.FromArgb(255, 216, 165);

        public static void EstsblecerPropiedadesBoton(Button button, bool enabled, Color backColor)
        {
            button.Enabled = enabled;
            button.BackColor = backColor;
        }
    }
    
}
