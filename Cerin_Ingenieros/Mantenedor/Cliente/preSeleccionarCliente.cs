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
        private List<entCliente> listaTodosClientes;
        private entCliente clienteSelecionado = null;


        public event EventHandler FormCerrado;
        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;

        public preSeleccionarCliente()
        {
            InitializeComponent();
            listaTodosClientes = logCliente.GetInstancia.listarClientes();
            ConfigCabecera();
            ListarClientes();
        }

        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dgvClientes,
                new string[] { "Id", "Nombre", "Apellido", "DNI", "RUC", "Razon social", "Telefono" });
            dgvClientes.Columns["Id"].Width = 50;
            dgvClientes.Columns["DNI"].Width = 80;
            dgvClientes.Columns["RUC"].Width = 100;
            dgvClientes.Columns["Telefono"].Width = 90;
        }

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

        public entCliente getCliente() { return clienteSelecionado; }

        private void btnSelecionarCliente_Click_1(object sender, EventArgs e)
        {
            SlecionarCliente();
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(clienteSelecionado));
            this.Close();
        }

        public class ClienteSeleccionadoEventArgs : EventArgs
        {
            public entCliente ClienteSeleccionado { get; }

            public ClienteSeleccionadoEventArgs(entCliente cliente)
            {
                ClienteSeleccionado = cliente;
            }
        }

        private void btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FormCerrado?.Invoke(this, EventArgs.Empty);
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SlecionarCliente();
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(clienteSelecionado));
            this.Close();
        }
    }
}
