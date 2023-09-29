using CapaLogica;
using Cerin_Ingenieros.Consultas;
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
        private bool isMinimized = false;
        private int m, mx, my;
        private Form FormActivo = null;
        private int rolUser;

        public Principal(int rol_user)
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            LoadForm();

            rolUser = rol_user;
            BotonesSegunRol();

            
        }

        private void BotonesSegunRol()
        {
            if (rolUser == 1)//admin
            {
                panelAlquiler.Visible = true;
                panelCalibracion.Visible = true;
                panelActualizarServicio.Visible = true;
                panelEquipoPrincipal.Visible = true;
                panelReportesPrincipal.Visible = true;
                panelEmpleado.Visible = true;
            }else if (rolUser == 2)//recepcionista
            {
                panelAlquiler.Visible = true;
                panelCalibracion.Visible = true;
                panelActualizarServicio.Visible = true;
                panelEquipoPrincipal.Visible = false;
                panelReportesPrincipal.Visible = true;
                panelEmpleado.Visible = false;
            }
            else if(rolUser == 3)//laboratorio
            {
                panelAlquiler.Visible = false;
                panelCalibracion.Visible = false;
                panelActualizarServicio.Visible = true;
                panelEquipoPrincipal.Visible = false;
                panelReportesPrincipal.Visible = true;
            }
        }

        private void LoadForm()
        {
            panelEquipo.Visible = false;
            panelReportes.Visible = false;
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

        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                escSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        private void escSubMenu()
        {
            if (panelEquipo.Visible == true)
                panelEquipo.Visible = false;
            if (panelEquipo.Visible == true)
                panelEquipo.Visible = false;
        }

        private void btn_empleado_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preEmpleado());
            LoadForm();
        }

        private void btn_equipo_Click(object sender, EventArgs e)
        {
            //AbrirFormHijo(new preEquipo());
            mostrarSubMenu(panelEquipo);
            panelReportes.Visible = false;
        }

        private void btn_alquiler_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preAlquiler());
            LoadForm();
        }

        private void btn_mantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMantenimiento());
            LoadForm();
        }

        private void btn_marca_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMarca());
        }

        private void btn_actualizar_servicio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preActualizarServicios());
            LoadForm();
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

        private void btnReportes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelReportes);
            panelEquipo.Visible = false;
        }

        private void btnNuevoEquipo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preEquipo());
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMarca());
        }

        private void btnNuevoModelo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preModelo());
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preEmpleado());
            LoadForm();
        }

        private void btnClienteSercio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preClienteServicio());
        }

        private void btnHistorialEquipo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preHistorialEquipo());
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.Activated += PrincipalForm_Activated;
        }

        private void PrincipalForm_Activated(object sender, EventArgs e)
        {
            // Verifica si el formulario está minimizado y lo restaura si es necesario
            if (isMinimized)
            {
                this.WindowState = FormWindowState.Normal;
                isMinimized = false;
            }
            else
            {
                // Puedes realizar acciones adicionales cuando el formulario se maximiza aquí
            }
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
