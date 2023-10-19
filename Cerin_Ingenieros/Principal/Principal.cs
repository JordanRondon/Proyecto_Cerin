using CapaLogica;
using Cerin_Ingenieros.Consultas;
using Cerin_Ingenieros.Mantenedor;
using Cerin_Ingenieros.Servicios;
using Cerin_Ingenieros.Servicios.ActualizarServicios;
using System;
using System.Windows.Forms;

namespace Cerin_Ingenieros
{
    public partial class Principal : Form
    {
        //Variables que permite minimizar y maximizar desde el icono del la barra de tareas
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;

        //FUNCION PARA MOVIMIENTO DEL FORMULARIO
        private int m, mx, my;

        //Otras variables
        private Form FormActivo = null;
        private readonly int RolUser;

        public Principal(int rol_user)
        {
            InitializeComponent();
            //Rol del usuario
            RolUser = rol_user;
            BotonesSegunRol();

            //establecer area de maximizacion
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        /// <summary>
        /// Metodo que se utiliza para minimizar la ventana desde la barra de tareas
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        /// <summary>
        /// Cargar el formulario de acuerdo al rol del usuario
        /// </summary>
        private void BotonesSegunRol()
        {
            if (logRol.GetInstancia.buscarRolNombre("Administrador").id_rol == RolUser)//ADMINISTRADOR
            {
                panelAlquiler.Visible = true;
                panelCalibracion.Visible = true;
                panelActualizarServicio.Visible = true;
                panelEquipoPrincipal.Visible = true;
                panelReportesPrincipal.Visible = true;
                panelEmpleado.Visible = true;
            }else if (logRol.GetInstancia.buscarRolNombre("Recepcionista").id_rol == RolUser)//RECEPCIONISTA
            {
                panelAlquiler.Visible = true;
                panelCalibracion.Visible = true;
                panelActualizarServicio.Visible = true;
                panelEquipoPrincipal.Visible = true;
                panelReportesPrincipal.Visible = true;
                panelEmpleado.Visible = false;

                panel12.Visible = false;
            }
            else if(logRol.GetInstancia.buscarRolNombre("Laboratorio").id_rol == RolUser)//LABORATORIO
            {
                panelAlquiler.Visible = false;
                panelCalibracion.Visible = false;
                panelActualizarServicio.Visible = true;
                panelEquipoPrincipal.Visible = false;
                panelReportesPrincipal.Visible = true;
                panelEmpleado.Visible = false;

                panel16.Visible = false;
                panel12.Visible = false;
            }
            else
            {
                MessageBox.Show("No hay vista para su rol.", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        
        /// <summary>
        /// Carga un formulario dentro de un panel en el formulario principal
        /// </summary>
        /// <param name="formhijo"> Formulario que se mostrara</param>
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
        /// <summary>
        /// Mostrar u ocultar un submenu que esta contendo dentro de un panel no visible
        /// </summary>
        /// <param name="subMenu">panel que se mostrara como submenu</param>
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OculatarSubMenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }
        /// <summary>
        /// Esconder el submenu activo
        /// </summary>
        private void OculatarSubMenu()
        {
            if (panelEquipo.Visible == true)
                panelEquipo.Visible = false;
            if (panelReportes.Visible == true)
                panelReportes.Visible = false;
        }

        //EVENTOS DE LOS BOTNOES(OPCIONES DEL USUARIO)
        private void btn_empleado_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preEmpleado());
            OculatarSubMenu();
        }

        private void btn_equipo_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelEquipo);
        }

        private void btn_alquiler_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preAlquiler());
            OculatarSubMenu();
        }   

        private void btn_mantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMantenimiento());
            OculatarSubMenu();
        }

        private void btn_marca_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preMarca());
        }

        private void btn_actualizar_servicio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preActualizarServicios(RolUser));
            OculatarSubMenu();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (FormActivo!=null)
            {
                FormActivo.Close();
            }
            Close();
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
                panel_principal.Invalidate();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                panel_principal.Invalidate();
            }
            this.Invalidate();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preModelo());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelReportes);
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
            OculatarSubMenu();
        }

        private void btnClienteSercio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preClienteServicio());
        }

        private void btnHistorialEquipo_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preHistorialEquipo());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new preVerServicios());
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormActivo != null)
            {
                FormActivo.Close();
            }
        }

        #region Movimiento del formulario
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
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
