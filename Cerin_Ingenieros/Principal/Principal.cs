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

namespace Cerin_Ingenieros
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btn_empleado_Click(object sender, EventArgs e)
        {
            preEmpleado preCliente = new preEmpleado();
            preCliente.Show();
        }

        private void btn_equipo_Click(object sender, EventArgs e)
        {
            preEquipo preEquipo = new preEquipo();
            preEquipo.Show();
        }

        private void btn_alquiler_Click(object sender, EventArgs e)
        {
            preAlquiler preAlquiler = new preAlquiler();
            preAlquiler.Show();
        }

        private void btn_mantenimiento_Click(object sender, EventArgs e)
        {
            preMantenimiento preMantenimiento = new preMantenimiento();
            preMantenimiento.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            preMarca preMarca = new preMarca();
            preMarca.Show();
        }
    }
}
