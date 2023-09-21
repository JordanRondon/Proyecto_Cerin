using CapaEntidad;
using Cerin_Ingenieros.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Consultas
{
    public partial class preClienteServicio : Form
    {
        private entCliente clienteSelecionado = null;

        public preClienteServicio()
        {
            InitializeComponent();
        }

        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSeleccionarCliente preSeleccionarCliente = new preSeleccionarCliente();
            preSeleccionarCliente.ShowDialog();

            clienteSelecionado = preSeleccionarCliente.getCliente();

            if (clienteSelecionado != null)
            {

                if (clienteSelecionado.Dni != null)
                {
                    lb_nombre_razonSocial.Text = clienteSelecionado.Nombre.ToString() + ' ' + clienteSelecionado.Apellido.ToString();
                    lb_dni_ruc.Text = clienteSelecionado.Dni.ToString();
                }
                else
                {
                    lb_nombre_razonSocial.Text = clienteSelecionado.RazonSocial.ToString();
                    lb_dni_ruc.Text = clienteSelecionado.Ruc.ToString();
                }
            }
            else MessageBox.Show("Cliente no exite");
        }
    }
}
