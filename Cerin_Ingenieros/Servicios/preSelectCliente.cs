using CapaDato;
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
    public partial class preSelectCliente : Form
    {
        //Variables registrar cliente
        private int id_Temporal = -1;

        //variables buscar cliente
        private List<entCliente> lisClienteselect;
        private entCliente selecionado = null;

        public preSelectCliente()
        {
            InitializeComponent();
            ListarClientes();
            ConfiguracionInicial();
        }


        #region RegistrarCliente
        private void ListarClientes()
        {
            List<entCliente> ls = logCliente.GetInstancia.listarClientes();
            dgvClientes2.DataSource = ls;
            dgvClientes.DataSource = ls;
        }

        private void ConfiguracionInicial()
        {
            btn_nuevo.Enabled = true;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;
            btn_cancelar_registro.Enabled = false;
            groupBoxRegistrar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_eliminar.Enabled = false;
        }
        private void ConfigNuevo()
        {
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_editar.Enabled = false;
            btn_cancelar_registro.Enabled = true;
            groupBoxRegistrar.Enabled = true;
            btn_buscar.Enabled = true;
            btn_eliminar.Enabled = false;
            txb_dni_cliente.Enabled = true;
            txb_apellidos_cliente.Enabled = true;
            txb_nombre_cliente.Enabled = true;
            txb_ruc_cliente.Enabled = true;
        }


        /// <summary>
        /// Manejador de eventos que valida que soo se ingrese numeros 
        /// </summary>
        /// <param name="sender">De donde se desencadeno el evento</param>
        /// <param name="e">Informacion del evento</param>

        private void ValidarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ConfigNuevo();
        }

        private void btn_cancelar_registro_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            ConfiguracionInicial();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            bool band1 = (txb_nombre_cliente.Text != "" && txb_apellidos_cliente.Text != "" && (txb_dni_cliente.Text != "" || txb_ruc_cliente.Text != ""));

            try
            {

                if (band1)
                {
                    entCliente cliente = new entCliente();

                    cliente.IdCliente = id_Temporal;
                    cliente.Nombre = txb_nombre_cliente.Text.Trim();
                    cliente.Apellido = txb_apellidos_cliente.Text.Trim();
                    cliente.Dni = txb_dni_cliente.Text.Trim();
                    cliente.Ruc = txb_ruc_cliente.Text.Trim();
                    cliente.Telefono = txb_telefono_cliente.Text.Trim();

                    logCliente.GetInstancia.editarCliente(cliente);
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            ListarClientes();
            ConfiguracionInicial();
            id_Temporal = -1;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            // verificar que la cadena tenga 8 caracteres, no esta vacia
            if (txb_dni_cliente.Text.Length == 8)
            {
                entApi clienteApi = logApi.GetInstancia.consultarDatosApi(txb_dni_cliente.Text);

                if (clienteApi != null)
                {
                    txb_nombre_cliente.Text = clienteApi.Nombre;
                    txb_apellidos_cliente.Text = clienteApi.Apellido;

                    txb_dni_cliente.Enabled = false;
                    txb_apellidos_cliente.Enabled = false;
                    txb_nombre_cliente.Enabled = false;
                }
                else
                {
                    MessageBox.Show("DNI no valida");
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool band1 = (txb_nombre_cliente.Text != "" && txb_apellidos_cliente.Text != "" && (txb_dni_cliente.Text != "" || txb_ruc_cliente.Text != ""));
            bool band2 = false;
            try
            {
                if ((txb_dni_cliente.Text != "" && txb_dni_cliente.Text.Length == 8))
                    band2 = logCliente.GetInstancia.ValidarDniUnica(txb_dni_cliente.Text.Trim());
                if ((txb_ruc_cliente.Text != "" && txb_ruc_cliente.Text.Length >= 10))
                    band2 = logCliente.GetInstancia.ValidarRucUnica(txb_ruc_cliente.Text.Trim());

                if (band1 && band2)
                {
                    entCliente cliente = new entCliente();

                    cliente.Nombre = txb_nombre_cliente.Text.Trim();
                    cliente.Apellido = txb_apellidos_cliente.Text.Trim();
                    cliente.Dni = txb_dni_cliente.Text.Trim();
                    cliente.Ruc = txb_ruc_cliente.Text.Trim();
                    cliente.Telefono = txb_telefono_cliente.Text.Trim();

                    logCliente.GetInstancia.insertarCliente(cliente);
                }
                else
                    MessageBox.Show("Casillas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            ListarClientes();
            ConfigNuevo();
        }

        private void dgvClientes2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaActual = dgvClientes2.Rows[e.RowIndex];

            id_Temporal = int.Parse(filaActual.Cells[0].Value.ToString());
            txb_nombre_cliente.Text = filaActual.Cells[1].Value.ToString();
            txb_apellidos_cliente.Text = filaActual.Cells[2].Value.ToString();
            txb_dni_cliente.Text = filaActual.Cells[3].Value.ToString();
            txb_ruc_cliente.Text = filaActual.Cells[4].Value.ToString();
            txb_telefono_cliente.Text = filaActual.Cells[5].Value.ToString();

            configEditar();

        }

        private void configEditar()
        {
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = true;
            btn_cancelar_registro.Enabled = true;
            groupBoxRegistrar.Enabled = true;
            btn_buscar.Enabled = false;
            btn_eliminar.Enabled = true;

            txb_dni_cliente.Enabled = false;
            txb_apellidos_cliente.Enabled = false;
            txb_nombre_cliente.Enabled = false;
            txb_ruc_cliente.Enabled = false;
        }
        #endregion RegistrarCliente

        #region BuscarCliente

        private void ListarClientes2()
        {
            dgvClientes.DataSource = lisClienteselect;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txb_buscar_cliente_KeyUp(object sender, KeyEventArgs e)
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

        private void SlecionarCliente()
        {
            if (dgvClientes.SelectedRows.Count>0)
            {
                DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];
                selecionado = new entCliente();
                selecionado.IdCliente = Convert.ToInt32(selectedRow.Cells[0].Value);
                selecionado.Nombre = Convert.ToString(selectedRow.Cells[1].Value);
                selecionado.Apellido = Convert.ToString(selectedRow.Cells[2].Value);
                selecionado.Dni = Convert.ToString(selectedRow.Cells[3].Value);
                selecionado.Ruc = Convert.ToString(selectedRow.Cells[4].Value);
                selecionado.Telefono = Convert.ToString(selectedRow.Cells[5].Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione un cliente");
            }
        }
        public entCliente getCliente() { return selecionado; }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            SlecionarCliente();
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SlecionarCliente();
        }
        #endregion BuscarCliente
    }
}
