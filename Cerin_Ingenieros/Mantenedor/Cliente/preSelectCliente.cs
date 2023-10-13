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
        private Form FormActivo = null;
        private entCliente cliente = null;
        public preSelectCliente()
        {
            InitializeComponent();
            AbrirFormHijo(new preSeleccionarCliente());
            btnSeleciionarCliente.BackColor = SystemColors.Control;
            btnRegistraCliente.BackColor = Color.White;
        }

        private void btnSeleciionarCliente_Click(object sender, EventArgs e)
        {
            btnSeleciionarCliente.BackColor = SystemColors.Control;
            btnRegistraCliente.BackColor = Color.White;

            AbrirFormHijo(new preSeleccionarCliente());
        }

        private void btnRegistraCliente_Click(object sender, EventArgs e)
        {
            btnSeleciionarCliente.BackColor = Color.White;
            btnRegistraCliente.BackColor = SystemColors.Control;
            AbrirFormHijo(new preRegistrarCliente());
            
        }

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

            // Suscribe al evento ClienteSeleccionado del formulario hijo actual (preSeleccionarCliente)
            if (formHijo is preSeleccionarCliente)
            {
                ((preSeleccionarCliente)formHijo).ClienteSeleccionado += (s, args) =>
                {
                    // Aquí puedes manejar el evento y reenviarlo al formulario principal (preSelectCliente)
                    cliente = args.ClienteSeleccionado;
                    OnClienteSeleccionado(cliente);
                };
            }

            formHijo.FormClosed += FormHijo_FormCerrado;
        }

        // Define un evento personalizado para notificar al formulario principal (preSelectCliente)
        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;

        // Método para disparar el evento
        protected virtual void OnClienteSeleccionado(entCliente cliente)
        {
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(cliente));
        }

        private void FormHijo_FormCerrado(object sender, EventArgs e)
        {
            // Cuando se cierre el formulario hijo, también cierra el formulario principal
            this.Close();
        }

        public entCliente getCliente()
        {
            return cliente;
        }
    }
}
