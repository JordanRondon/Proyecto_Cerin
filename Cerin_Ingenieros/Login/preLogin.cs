﻿using CapaEntidad;
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
        private int m, mx, my;
        public preLogin()
        {
            InitializeComponent();

            List<entEquipo> equiposSelecionados = new List<entEquipo>();
            equiposSelecionados.Add(logEquipo.GetInstancia.buscarEquipo("1"));
            entCliente clienteSelecionado = logCliente.GetInstancia.buscarClienteId(1);
            entServicio servicio = logServicio.GetInstancia.buscarServicio(1);
            string file = logComprobante.GetInstancia.generarComprobante(servicio, clienteSelecionado, equiposSelecionados, "");
            if (file != null)
            {
                //preViewCertificado preView = new preViewCertificado(file);
                //preView.Show();

                Process.Start(file);
            }
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
