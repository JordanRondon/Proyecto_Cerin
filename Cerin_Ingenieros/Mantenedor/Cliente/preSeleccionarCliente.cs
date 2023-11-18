
// --------------------------------------------------------------
// Nombre del archivo: preSeleccionarCliente.cs
// Descripción: Clase que gestiona la interfaz de selección de
//              clientes para el sistema.
// --------------------------------------------------------------

using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preSeleccionarCliente : Form
    {
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private List<entCliente> listaTodosClientes;
        private entCliente clienteSelecionado = null;

        /// <summary>
        /// Evento que se dispara cuando se cierra el formulario.
        /// </summary>
        public event EventHandler FormCerrado;

        /// <summary>
        /// Evento que se dispara cuando se selecciona un cliente.
        /// </summary>
        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;

        public preSeleccionarCliente()
        {
            InitializeComponent();
            listaTodosClientes = logCliente.GetInstancia.listarClientes();
            ConfigCabecera();
            ListarClientes();
        }

        /// <summary>
        /// Configura la cabecera de la tabla de clientes en la interfaz.
        /// </summary>
        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dgvClientes,
                new string[] { "Id", "Nombre", "Apellido", "DNI", "RUC", "Razon social", "Telefono" });
            dgvClientes.Columns["Id"].Width = 50;
            dgvClientes.Columns["DNI"].Width = 80;
            dgvClientes.Columns["RUC"].Width = 100;
            dgvClientes.Columns["Telefono"].Width = 90;
        }

        /// <summary>
        /// Lista todos los clientes en la interfaz.
        /// </summary>
        private void ListarClientes()
        {
            List<entCliente> ls = listaTodosClientes;

            foreach (var item in ls)
            {
                dgvClientes.Rows.Add(
                    item.IdCliente,
                    item.Nombre,
                    item.Apellido,
                    item.Dni,
                    item.Ruc,
                    item.RazonSocial,
                    item.Telefono
                );
            }
        }

        /// <summary>
        /// Selecciona el cliente actualmente resaltado en la interfaz. 
        /// </summary>
        private void SlecionarCliente()
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];
                clienteSelecionado = new entCliente();
                clienteSelecionado.IdCliente = Convert.ToInt32(selectedRow.Cells[0].Value);
                clienteSelecionado.Nombre = Convert.ToString(selectedRow.Cells[1].Value);
                clienteSelecionado.Apellido = Convert.ToString(selectedRow.Cells[2].Value);
                clienteSelecionado.Dni = Convert.ToString(selectedRow.Cells[3].Value);
                clienteSelecionado.Ruc = Convert.ToString(selectedRow.Cells[4].Value);
                clienteSelecionado.RazonSocial = Convert.ToString(selectedRow.Cells[5].Value);
                clienteSelecionado.Telefono = Convert.ToString(selectedRow.Cells[6].Value);
            }
            else
            {
                MessageBox.Show("No se a selecionado Ningun cliente");
            }
        }

        /// <summary>
        /// Obtiene el cliente seleccionado en la interfaz.
        /// </summary>
        /// <returns>El cliente seleccionado.</returns>
        public entCliente getCliente() { return clienteSelecionado; }

        /// <summary>
        /// Maneja el evento de clic en el botón de seleccionar cliente.
        /// </summary>
        private void btnSelecionarCliente_Click_1(object sender, EventArgs e)
        {
            SlecionarCliente();
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(clienteSelecionado));
            this.Close();
        }

        /// <summary>
        /// Clase que define los argumentos para el evento ClienteSeleccionado.
        /// </summary>
        public class ClienteSeleccionadoEventArgs : EventArgs
        {
            public entCliente ClienteSeleccionado { get; }

            public ClienteSeleccionadoEventArgs(entCliente cliente)
            {
                ClienteSeleccionado = cliente;
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de cancelar.
        /// </summary>
        private void btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Maneja el evento KeyUp en el cuadro de texto de búsqueda.
        /// </summary>
        private void txb_buscar_cliente_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txb_buscar_cliente.Text))
            {
                if (rb_dni.Checked)
                {
                    listaTodosClientes = logCliente.GetInstancia.listarClienteDni(txb_buscar_cliente.Text);
                }
                else if (rb_nombre.Checked)
                {
                    listaTodosClientes = logCliente.GetInstancia.listarClienteNombre(Convert.ToString(txb_buscar_cliente.Text));
                }
                else if (rb_RUC.Checked)
                {
                    listaTodosClientes = logCliente.GetInstancia.listarClienteRuc(Convert.ToString(txb_buscar_cliente.Text));
                }
            }
            else
            {
                listaTodosClientes = logCliente.GetInstancia.listarClientes();
            }
            ListarClientes();

        }

        /// <summary>
        /// Sobrecarga del método OnFormClosed que maneja el evento de cierre
        /// del formulario.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FormCerrado?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Maneja el evento de doble clic en una celda de la tabla de clientes.
        /// </summary>
        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SlecionarCliente();
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(clienteSelecionado));
            this.Close();
        }
    }
}
