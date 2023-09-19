using CapaLogica;
using Cerin_Ingenieros.Mantenedor;
using Cerin_Ingenieros.Servicios;
using Cerin_Ingenieros.Servicios.ActualizarServicios;
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
        //FUNCION PARA MOVIMIENTO DEL FORMULARIO
        private int m, mx, my;
        private Form FormActivo = null;

        public Principal()
        {
            InitializeComponent();
        }
        //funcion para el acceso a los formulario
        private void AbrirFormHijo(Form formhijo)
        {
            if (FormActivo != null)
                FormActivo.Close();
            FormActivo = formhijo;
            formhijo.TopLevel = false;
            formhijo.FormBorderStyle = FormBorderStyle.None;
            formhijo.Dock = DockStyle.Fill;
            panel_principal.Controls.Add(formhijo);
            panel_principal.Tag = formhijo;
            formhijo.BringToFront();
            formhijo.Show();
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

        private void btn_actualizar_servicio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preActualizarServicios());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (FormActivo!=null)
            {
                FormActivo.Close();
            }
            Close();
        }
        #region Movimiento del formulario
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnPantallaCom_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preModelo());
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m==1)
            {
                this.SetDesktopLocation(MousePosition.X-mx,MousePosition.Y-my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
        #endregion Movimiento del formulario

    }
}
