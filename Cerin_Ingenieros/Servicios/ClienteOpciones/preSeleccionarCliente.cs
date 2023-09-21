using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.Servicios
{
    public partial class preSeleccionarCliente : Form
    {
        //variables buscar cliente
        private List<entCliente> lisClienteselect;
        private entCliente selecionado = null;
        public event EventHandler FormCerrado;

        public event EventHandler<ClienteSeleccionadoEventArgs> ClienteSeleccionado;


        public preSeleccionarCliente()
        {
            InitializeComponent();
            ListarClientes();
        }

        private void ListarClientes2()
        {
            dgvClientes.DataSource = lisClienteselect;
        }

        private void ListarClientes()
        {
            List<entCliente> ls = logCliente.GetInstancia.listarClientes();
            dgvClientes.DataSource = ls;
        }

        private void SlecionarCliente()
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];
                selecionado = new entCliente();
                selecionado.IdCliente = Convert.ToInt32(selectedRow.Cells[0].Value);
                selecionado.Nombre = Convert.ToString(selectedRow.Cells[1].Value);
                selecionado.Apellido = Convert.ToString(selectedRow.Cells[2].Value);
                selecionado.Dni = Convert.ToString(selectedRow.Cells[3].Value);
                selecionado.Ruc = Convert.ToString(selectedRow.Cells[4].Value);
                selecionado.RazonSocial = Convert.ToString(selectedRow.Cells[5].Value);
                selecionado.Telefono = Convert.ToString(selectedRow.Cells[6].Value);
            }
            else
            {
                MessageBox.Show("Selecione un cliente");
            }
        }

        public entCliente getCliente() { return selecionado; }

        private void btnSelecionarCliente_Click_1(object sender, EventArgs e)
        {
            SlecionarCliente();
            ClienteSeleccionado?.Invoke(this, new ClienteSeleccionadoEventArgs(selecionado));
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
                    lisClienteselect = logCliente.GetInstancia.listarClienteDni(txb_buscar_cliente.Text);
                }
                else if (rb_nombre.Checked)
                {
                    lisClienteselect = logCliente.GetInstancia.listarClienteNombre(Convert.ToString(txb_buscar_cliente.Text));
                }
                else if (rb_RUC.Checked)
                {
                    lisClienteselect = logCliente.GetInstancia.listarClienteRuc(Convert.ToString(txb_buscar_cliente.Text));
                }
            }
            else
            {
                lisClienteselect = logCliente.GetInstancia.listarClientes();
            }
            ListarClientes2();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FormCerrado?.Invoke(this, EventArgs.Empty);
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ver si se puede implementar
        }
    }
}
