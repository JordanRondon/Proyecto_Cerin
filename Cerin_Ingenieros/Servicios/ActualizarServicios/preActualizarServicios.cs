using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios.ActualizarServicios
{
    public partial class preActualizarServicios : Form
    {
        public preActualizarServicios()
        {
            InitializeComponent();
            
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            entServicio servicioActual = new entServicio();
            if (logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString())) != null)
            {
                servicioActual = logServicio.GetInstancia.buscarServicio(Convert.ToInt32(txb_id_Servicio.Text.ToString()));
                label_nombre_ruc_cliente.Text = servicioActual.IdCliente.ToString();
                label_tipo_Servicio.Text = servicioActual.IdTipo.ToString();
            }
            else
                MessageBox.Show("Código de Servicio inexistente");
        }
    }
}
