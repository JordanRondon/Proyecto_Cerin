using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preSelectCliente : Form
    {
        public preSelectCliente()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Manejador de eventos que valida que soo se ingrese numeros 
        /// </summary>
        /// <param name="sender">De donde se desencadeno el evento</param>
        /// <param name="e">Informacion del evento</param>

        private void ValidarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
