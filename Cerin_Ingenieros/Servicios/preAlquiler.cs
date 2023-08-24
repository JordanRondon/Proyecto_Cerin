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
    public partial class preAlquiler : Form
    {
        public preAlquiler()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            preAgregarEquipo preAgregarEquipo   = new preAgregarEquipo();
            preAgregarEquipo.ShowDialog();
        }
    }
}
