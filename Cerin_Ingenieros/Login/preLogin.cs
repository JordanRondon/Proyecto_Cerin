
// --------------------------------------------------------------
// Nombre del archivo: preLogin.cs
// Descripción: Clase parcial que gestiona la interfaz de inicio
//              de sesión de la aplicación.
// --------------------------------------------------------------

using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Login
{
    public partial class preLogin : Form
    {
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private readonly string messageUserDefect = "Usuario";
        private readonly string messagePasswordDefect = "Contraseña";

        private readonly Color colorMessage = Color.FromArgb(144, 144, 144);
        private readonly Color colorText = Color.Black;

        public preLogin()
        {
            InitializeComponent();
            ConigInicialTextos();
        }

        // --------------------------------------------------------------
        /// <summary>
        /// Configuración inicial de los cuadros de texto en la interfaz.
        /// </summary>
        private void ConigInicialTextos()
        {
            txbUser.Text = messageUserDefect;
            txbUser.ForeColor = colorMessage;
            txbContra.Text = messagePasswordDefect;
            txbContra.ForeColor = colorMessage;
        }
        #region Eventos
        /// <summary>
        /// Evento que cierra la ventana de inicio de sesión.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento que minimiza la ventana de inicio de sesión.
        /// </summary>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Evento que maneja el inicio de sesión.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txbUser.Text;
            string contra = txbContra.Text;
            int estado = 0;

            if (user != null && contra != null)
            {
                estado = logUser.GetInstancia.validarInicioSesion(user,classEncriptar.EncriptarContraseña(contra));
            }
            else if (contra == "" && user == "") MessageBox.Show("complete los campos");
            else if (user == "") MessageBox.Show("Ingrese su usuario");
            else MessageBox.Show("Ingrese su contraseña");
            if (estado >= 1)
            {
                this.Hide();
                Principal principal = new Principal(estado);
                principal.ShowDialog();
                this.Show();
                ConigInicialTextos();
            }
            else
            {
                MessageBox.Show("Contraseña o usuario no validos");
            }
        }

        /// <summary>
        /// Evento que maneja la entrada al cuadro de usuario.
        /// </summary>
        private void txbUser_Enter(object sender, EventArgs e)
        {
            if (txbUser.Text == messageUserDefect)
            {
                txbUser.Text = "";
                txbUser.ForeColor = colorText;
            }
        }

        /// <summary>
        /// Evento que maneja la salida del cuadro de usuario.
        /// </summary>
        private void txbUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbUser.Text))
            {
                txbUser.Text = messageUserDefect;
                txbUser.ForeColor = colorMessage;
            }
        }

        /// <summary>
        /// Evento que maneja la entrada al cuadro de contraseña.
        /// </summary>
        private void txbContra_Enter(object sender, EventArgs e)
        {
            if (txbContra.Text == messagePasswordDefect)
            {
                txbContra.Text = "";
                txbContra.ForeColor = colorText;
                txbContra.PasswordChar = '*';
            }
        }

        /// <summary>
        /// Evento que maneja la salida del cuadro de contraseña.
        /// </summary>
        private void txbContra_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbContra.Text))
            {
                txbContra.Text = messagePasswordDefect;
                txbContra.ForeColor = colorMessage;
                txbContra.PasswordChar = '\0';
            }
        }
        #endregion Eventos
    }
}
