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
        //funcion para el acceso a los formulario
        private void AbrirFormHijo(object formhijo)
        {
            if (this.panel_principal.Controls.Count > 0)
                this.panel_principal.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_principal.Controls.Add(fh);
            this.panel_principal.Tag = fh;
            fh.Show();
        }


        private void btn_empleado_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preEmpleado());
        }

        private void btn_equipo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preEquipo());
        }

        private void btn_alquiler_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preAlquiler());
        }

        private void btn_mantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMantenimiento());
        }

        private void btn_marca_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMarca());
        }
    }
}
