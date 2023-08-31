using Cerin_Ingenieros.Servicios.Mantenimiento;
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
    public partial class preMantenimiento : Form
    {
        public preMantenimiento()
        {
            InitializeComponent();
            inicializarVariablesAux();
        }
        private void inicializarVariablesAux()
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_select_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();
        }

        private void btn_agregar_equipo_Click(object sender, EventArgs e)
        {
            preRegistEquipoMantenimiento preRegistEquipoMantenimiento = new preRegistEquipoMantenimiento();
            preRegistEquipoMantenimiento.ShowDialog();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbFecha.Text = DateTime.Now.ToLongDateString();

            ///agunos cambios



        }

        private void btn_slect_cliente_Click(object sender, EventArgs e)
        {
            preSelectCliente preSelectCliente = new preSelectCliente();
            preSelectCliente.ShowDialog();
        }

        private void btn_agregar_equipo_Click_1(object sender, EventArgs e)
        {
            preRegistEquipoMantenimiento rem = new preRegistEquipoMantenimiento();
            rem.ShowDialog();
        }
    }
}
