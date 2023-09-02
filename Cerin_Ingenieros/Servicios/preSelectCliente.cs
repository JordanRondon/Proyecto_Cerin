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
        public preSelectCliente()
        {
            InitializeComponent();
            ListarClientes();
            ConfiguracionInicial();
        }
        private void ListarClientes()
        {
            List<entCliente> lista = logCliente.GetInstancia.listarClientes();
            dgvClientes.DataSource = lista;
            dgvClientes2.DataSource = lista;
        }

        private void ConfiguracionInicial()
        {
            btn_nuevo.Enabled = true;
            btn_guardar.Enabled = false;
            btn_editar.Enabled = false;
            btn_cancelar.Enabled = false;
            groupBoxRegistrar.Enabled = false;
            btn_buscar.Enabled = false;
            btn_eliminar.Enabled = false;
        }
        private void ConfigNuevo()
        {
            btn_nuevo.Enabled = false;
            btn_guardar.Enabled = true;
            btn_editar.Enabled = false;
            btn_cancelar.Enabled = true;
            groupBoxRegistrar.Enabled = true;
            btn_buscar.Enabled = true;
            btn_eliminar.Enabled = true;
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

            ConfiguracionInicial();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            // verificar que la cadena tenga 8 caracteres, no esta vacia
            if (txb_dni_cliente.Text.Length==8)
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

            try
            {

                if (band1)
                {
                    entCliente cliente = new entCliente();

                    cliente.Nombre = txb_nombre_cliente.Text.Trim();
                    cliente.Apellido = txb_apellidos_cliente.Text.Trim();
                    cliente.Dni = txb_dni_cliente.Text.Trim();
                    cliente.Ruc = txb_ruc_cliente.Text.Trim() ;
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

            ConfigNuevo();
            ListarClientes();
        }
    }
}
