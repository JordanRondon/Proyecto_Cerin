using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Login
{
    public partial class preLogin : Form
    {
        private readonly string messageUserDefect = "Usuario";
        private readonly string messagePasswordDefect = "Contraseña";

        private readonly Color colorMessage = Color.FromArgb(144, 144, 144);
        private readonly Color colorText = Color.White;

        public preLogin()
        {
            InitializeComponent();
            txbUser.Text = messageUserDefect;
            txbUser.ForeColor = colorMessage;
            txbContra.Text = messagePasswordDefect;
            txbContra.ForeColor = colorMessage;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

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
            }
            else
            {
                MessageBox.Show("Contraseña o usuario no validos");
            }
        }
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txbUser_Enter(object sender, EventArgs e)
        {
            if (txbUser.Text == messageUserDefect)
            {
                txbUser.Text = "";
                txbUser.ForeColor = colorText;
            }
        }

        private void txbUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbUser.Text))
            {
                txbUser.Text = messageUserDefect;
                txbUser.ForeColor = colorMessage;
            }
        }

        private void txbContra_Enter(object sender, EventArgs e)
        {
            if (txbContra.Text == messagePasswordDefect)
            {
                txbContra.Text = "";
                txbContra.ForeColor = colorText;
                txbContra.PasswordChar = '*';
            }
        }

        private void txbContra_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbContra.Text))
            {
                txbContra.Text = messagePasswordDefect;
                txbContra.ForeColor = colorMessage;
                txbContra.PasswordChar = '\0';
            }
        }
    }
}
