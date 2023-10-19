using CapaEntidad;
using Cerin_Ingenieros.Servicios.ClienteOpciones;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Cerin_Ingenieros.Servicios.preSeleccionarCliente;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preSelectCliente : Form
    {

        private Form FormActivo = null;         //Formulario activo
        private entCliente cliente = null;      //Cliente selecionado
        public preSelectCliente()
        {
            InitializeComponent();
            SelecForCliente();
        }

        #region EVENTOS BOTONES
        private void btnSeleciionarCliente_Click(object sender, EventArgs e)
        {
            SelecForCliente();
        }

        private void btnRegistraCliente_Click(object sender, EventArgs e)
        {
            btnSeleciionarCliente.BackColor = Color.White;
            btnRegistraCliente.BackColor = Color.FromArgb(255, 224, 192);
            AbrirFormHijo(new preRegistrarCliente());
            
        }

        private void FormHijo_FormCerrado(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelecForCliente()
        {
            btnSeleciionarCliente.BackColor = Color.FromArgb(255, 224, 192);
            btnRegistraCliente.BackColor = Color.White;

            AbrirFormHijo(new preSeleccionarCliente());
        }
        #endregion EVENTOS BOTONES

        #region MOSTRA FORMULARIOS
        private void AbrirFormHijo(Form formHijo)
        {
            if (FormActivo != null)
            {
                FormActivo.FormClosed -= FormHijo_FormCerrado;
                FormActivo.Close();
            }

            FormActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(formHijo);
            panelPrincipal.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();

            if (formHijo is preSeleccionarCliente)
            {
                ((preSeleccionarCliente)formHijo).ClienteSeleccionado += (s, args) =>
                {
                    cliente = args.ClienteSeleccionado;
                    OnClienteSeleccionado(cliente);
                };
            }

            formHijo.FormClosed += FormHijo_FormCerrado;
        }
        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;

        protected virtual void OnClienteSeleccionado(entCliente cliente)
        {
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(cliente));
        }

        public entCliente getCliente()
        {
            return cliente;
        }
        #endregion MOSTRA FORMULARIOS
    }
}
