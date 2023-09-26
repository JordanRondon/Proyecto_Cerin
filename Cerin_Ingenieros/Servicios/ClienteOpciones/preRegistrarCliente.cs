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

namespace Cerin_Ingenieros.Servicios.ClienteOpciones
{
    public partial class preRegistrarCliente : Form
    {
        //Variables registrar cliente
        private int id_Temporal = -1;

        public preRegistrarCliente()
        {
            InitializeComponent();
            ListarClientes();
            ConfiguracionInicial();
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
            txb_razonSocial_cliente.Enabled = false;
        }

        private void LimpiarVariables()
        {
            txb_dni_cliente.Text = "";
            txb_apellidos_cliente.Text = "";
            txb_nombre_cliente.Text = "";
            txb_ruc_cliente.Text = "";
            txb_telefono_cliente.Text = "";
            txb_razonSocial_cliente.Text = "";
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
            txb_razonSocial_cliente.Enabled = true;

            LimpiarVariables();
        }

        private void ListarClientes()
        {
            List<entCliente> ls = logCliente.GetInstancia.listarClientes();
            dgvClientes2.DataSource = ls;
        }

        private void datosCliente(string DNI)
        {
            entApi clienteApi = logApi.GetInstancia.consultarDatosApi(DNI);
            if (clienteApi != null)
            {
                txb_nombre_cliente.Text = clienteApi.Nombre;
                txb_apellidos_cliente.Text = clienteApi.Apellido;

                txb_dni_cliente.Enabled = false;
                txb_apellidos_cliente.Enabled = false;
                txb_nombre_cliente.Enabled = false;
            }
            else { MessageBox.Show("DNI no valida"); }
        }

        private void datosRuc(string RUC)
        {
            entApi clienteApi = logApi.GetInstancia.consultarDatosApi(txb_ruc_cliente.Text.Trim());
            if (clienteApi != null)
            {
                txb_razonSocial_cliente.Text = clienteApi.razonSocial;

                txb_ruc_cliente.Enabled = false;
                txb_razonSocial_cliente.Enabled = false;
            }
            else { MessageBox.Show("RUC no valida"); }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ConfigNuevo();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            // verificar que la cadena tenga 8 caracteres, no esta vacia
            if (txb_dni_cliente.Text.Length == 8)
            {
                datosCliente(txb_dni_cliente.Text.Trim());
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool band1 = (txb_apellidos_cliente.Text !="" && txb_nombre_cliente.Text !="" && txb_dni_cliente.Text!="") || (txb_razonSocial_cliente.Text != "" && txb_razonSocial_cliente.Text!="");
            bool band2 = (logCliente.GetInstancia.ValidarDniUnica(txb_dni_cliente.Text.Trim()) || logCliente.GetInstancia.ValidarRucUnica(txb_ruc_cliente.Text.Trim()));
            try
            {
                if (band2)
                {
                    if (band1)
                    {
                        entCliente cliente = new entCliente();

                        cliente.Nombre = txb_nombre_cliente.Text.Trim();
                        cliente.Apellido = txb_apellidos_cliente.Text.Trim();
                        cliente.Dni = txb_dni_cliente.Text.Trim();
                        cliente.Ruc = txb_ruc_cliente.Text.Trim();
                        cliente.RazonSocial = txb_razonSocial_cliente.Text.Trim();
                        cliente.Telefono = txb_telefono_cliente.Text.Trim();

                        logCliente.GetInstancia.insertarCliente(cliente);
                    }
                    else
                        MessageBox.Show("Casillas vacias", "Error");
                }
                else MessageBox.Show("Valores ya registrados");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            ListarClientes();
            ConfigNuevo();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                entCliente cliente = new entCliente();

                cliente.IdCliente = id_Temporal;
                cliente.Nombre = txb_nombre_cliente.Text.Trim();
                cliente.Apellido = txb_apellidos_cliente.Text.Trim();
                cliente.Dni = txb_dni_cliente.Text.Trim();
                cliente.Ruc = txb_ruc_cliente.Text.Trim();
                cliente.RazonSocial = txb_razonSocial_cliente.Text.Trim();
                cliente.Telefono = txb_telefono_cliente.Text.Trim();

                logCliente.GetInstancia.editarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            ListarClientes();
            ConfiguracionInicial();
            LimpiarVariables();
            id_Temporal = -1;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            bool datosIngresados = (txb_nombre_cliente.Text != "" && txb_apellidos_cliente.Text != "" && txb_dni_cliente.Text != "");

            try
            {
                if (id_Temporal>=0)
                {
                    logCliente.GetInstancia.deshabilitarCliente(id_Temporal);
                }
                else
                {
                    MessageBox.Show("Casilla vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }

            ListarClientes();
            ConfiguracionInicial();
            LimpiarVariables();
            id_Temporal = -1;
        }

        private void btn_cancelar_registro_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            LimpiarVariables();
        }

        private void dgvClientes2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaActual = dgvClientes2.Rows[e.RowIndex];

                id_Temporal = int.Parse(filaActual.Cells[0].Value.ToString());
                txb_nombre_cliente.Text = filaActual.Cells[1].Value.ToString();
                txb_apellidos_cliente.Text = filaActual.Cells[2].Value.ToString();
                txb_dni_cliente.Text = filaActual.Cells[3].Value.ToString();
                txb_ruc_cliente.Text = filaActual.Cells[4].Value.ToString();
                txb_razonSocial_cliente.Text = filaActual.Cells[5].Value.ToString();
                txb_telefono_cliente.Text = filaActual.Cells[6].Value.ToString();

                configEditar();
            }
        }

        private void btnBuscarRuc_Click(object sender, EventArgs e)
        {
            if (txb_ruc_cliente.Text.Length == 11)
            {
                datosRuc(txb_ruc_cliente.Text.Trim());
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
