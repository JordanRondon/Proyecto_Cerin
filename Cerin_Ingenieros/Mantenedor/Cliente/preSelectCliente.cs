
// --------------------------------------------------------------
// Nombre del archivo: preSelectCliente.cs
// Descripción: Clase que gestiona la interfaz de usuario para la
//              selección y registro de clientes.
// --------------------------------------------------------------

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
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private Form FormActivo = null;         //Formulario activo
        private entCliente cliente = null;      //Cliente selecionado
        public preSelectCliente()
        {
            InitializeComponent();
            SelecForCliente();
        }

        #region EVENTOS BOTONES

        /// <summary>
        /// Maneja el evento de clic en el botón "Seleccionar Cliente".
        /// </summary>
        private void btnSeleciionarCliente_Click(object sender, EventArgs e)
        {
            SelecForCliente();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón "Registrar Cliente".
        /// </summary>
        private void btnRegistraCliente_Click(object sender, EventArgs e)
        {
            btnSeleciionarCliente.BackColor = Color.White;
            btnRegistraCliente.BackColor = Color.FromArgb(255, 224, 192);
            AbrirFormHijo(new preRegistrarCliente());
            
        }

        /// <summary>
        /// Maneja el evento de cierre de formularios hijos.
        /// </summary>
        private void FormHijo_FormCerrado(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Realiza la selección del formulario "preSeleccionarCliente".
        /// </summary>
        private void SelecForCliente()
        {
            btnSeleciionarCliente.BackColor = Color.FromArgb(255, 224, 192);
            btnRegistraCliente.BackColor = Color.White;

            AbrirFormHijo(new preSeleccionarCliente());
        }
        #endregion EVENTOS BOTONES

        #region MOSTRA FORMULARIOS

        /// <summary>
        /// Abre un formulario hijo en el panel principal.
        /// </summary>
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

        /// <summary>
        /// Evento que se dispara cuando se selecciona un cliente.
        /// </summary>
        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;

        /// <summary>
        /// Invoca el evento de cliente seleccionado.
        /// </summary>
        protected virtual void OnClienteSeleccionado(entCliente cliente)
        {
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(cliente));
        }

        /// <summary>
        /// Obtiene el cliente seleccionado.
        /// </summary>
        public entCliente getCliente()
        {
            return cliente;
        }
        #endregion MOSTRA FORMULARIOS
    }
}
