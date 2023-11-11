using CapaEntidad;
using CapaLogica;
using Cerin_Ingenieros.RecursosAdicionales.Clases;
using System;
using System.Collections.Generic;
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
            ConfiguracionInicial();
            ConfigCabecera();
            ListarClientes();
        }

        #region CONFIGURACION DEL FORMULARIO
        private void ConfigCabecera()
        {
            dgvConfiguracion.ConfigurarColumnas(dgvClientes,
                new string[] { "Id", "Nombre", "Apellido", "DNI", "RUC", "Razon social", "Telefono" });
            dgvClientes.Columns["Id"].Width = 50;
            dgvClientes.Columns["DNI"].Width = 80;
            dgvClientes.Columns["RUC"].Width = 100;
            dgvClientes.Columns["Telefono"].Width = 90;
        }

        private void ConfiguracionInicial()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar_registro, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_buscar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btnBuscarRuc, false, configColores.btDesactivado);


            txb_dni_cliente.Enabled = false;
            txb_apellidos_cliente.Enabled = false;
            txb_nombre_cliente.Enabled = false;
            txb_ruc_cliente.Enabled = false;
            txb_razonSocial_cliente.Enabled = false;
            txb_telefono_cliente.Enabled = false;
        }

        private void configEditar()
        {
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_editar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar_registro, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_buscar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btnBuscarRuc, true, configColores.btnActivo);

            txb_dni_cliente.Enabled = false;
            txb_apellidos_cliente.Enabled = false;
            txb_nombre_cliente.Enabled = false;
            txb_ruc_cliente.Enabled = true;
            txb_razonSocial_cliente.Enabled = true;
            txb_telefono_cliente.Enabled = true;
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
            configColores.EstsblecerPropiedadesBoton(btn_nuevo, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_guardar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_editar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btn_cancelar_registro, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_buscar, true, configColores.btnActivo);
            configColores.EstsblecerPropiedadesBoton(btn_eliminar, false, configColores.btDesactivado);
            configColores.EstsblecerPropiedadesBoton(btnBuscarRuc, true, configColores.btnActivo);

            txb_dni_cliente.Enabled = true;
            txb_apellidos_cliente.Enabled = true;
            txb_nombre_cliente.Enabled = true;
            txb_ruc_cliente.Enabled = true;
            txb_razonSocial_cliente.Enabled = true;
            txb_telefono_cliente.Enabled = true;

            LimpiarVariables();
        }

        private void ListarClientes()
        {
            dgvClientes.Rows.Clear();
            List<entCliente> ls = logCliente.GetInstancia.listarClientes();

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
        #endregion CONFIGURACION DEL FORMULARIO

        #region API_DNI_RUC
        /// <summary>
        /// Consulta los datos del cliente por DNI y muestra la información en los controles.
        /// </summary>
        /// <param name="DNI">Número de DNI a consultar.</param>
        private void DatosCliente(string DNI)
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

        /// <summary>
        /// Consulta los datos del cliente por RUC y muestra la información en los controles.
        /// </summary>
        /// <param name="RUC">Número de RUC a consultar.</param>
        private void DatosRuc(string RUC)
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

        #endregion API_DNI_RUC

        #region eventos botones
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ConfigNuevo();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txb_dni_cliente.Text.Length == 8)
            {
                DatosCliente(txb_dni_cliente.Text.Trim());
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool hayDatosMinimos = (txb_apellidos_cliente.Text !="" && txb_nombre_cliente.Text !="" && txb_dni_cliente.Text!="") || (txb_razonSocial_cliente.Text != "" && txb_razonSocial_cliente.Text!="");
            bool DatoUnico = (logCliente.GetInstancia.ValidarDniUnica(txb_dni_cliente.Text.Trim()) || logCliente.GetInstancia.ValidarRucUnica(txb_ruc_cliente.Text.Trim()));
            try
            {
                if (DatoUnico)
                {
                    if (hayDatosMinimos)
                    {
                        entCliente cliente = new entCliente();

                        cliente.Nombre = txb_nombre_cliente.Text.Trim();
                        cliente.Apellido = txb_apellidos_cliente.Text.Trim();
                        cliente.Dni = txb_dni_cliente.Text.Trim();
                        cliente.Ruc = txb_ruc_cliente.Text.Trim();
                        cliente.RazonSocial = txb_razonSocial_cliente.Text.Trim();
                        cliente.Telefono = txb_telefono_cliente.Text.Trim();

                        logCliente.GetInstancia.insertarCliente(cliente);

                        ListarClientes();
                        ConfigNuevo();
                    }
                    else
                        MessageBox.Show("Casillas vacias", "Error");
                }
                else 
                {
                    MessageBox.Show("Valores ya registrados");
                    ListarClientes();
                    ConfigNuevo();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }            
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                bool hayDatosMinimos = (txb_apellidos_cliente.Text != "" && txb_nombre_cliente.Text != "" && txb_dni_cliente.Text != "") || (txb_razonSocial_cliente.Text != "" && txb_razonSocial_cliente.Text != "");
                bool DatoUnico = (logCliente.GetInstancia.ValidarDniUnica(txb_dni_cliente.Text.Trim()) || logCliente.GetInstancia.ValidarRucUnica(txb_ruc_cliente.Text.Trim()));

                entCliente cliente = new entCliente
                {
                    IdCliente = id_Temporal,
                    Nombre = txb_nombre_cliente.Text.Trim(),
                    Apellido = txb_apellidos_cliente.Text.Trim(),
                    Dni = txb_dni_cliente.Text.Trim(),
                    Ruc = txb_ruc_cliente.Text.Trim(),
                    RazonSocial = txb_razonSocial_cliente.Text.Trim(),
                    Telefono = txb_telefono_cliente.Text.Trim()
                };

                logCliente.GetInstancia.editarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.." + ex);
            }
            finally
            {
                ListarClientes();
                ConfiguracionInicial();
                LimpiarVariables();
                id_Temporal = -1;
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
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
            finally
            {
                ListarClientes();
                ConfiguracionInicial();
                LimpiarVariables();
                id_Temporal = -1;
            }

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
                DataGridViewRow filaActual = dgvClientes.Rows[e.RowIndex];

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
                DatosRuc(txb_ruc_cliente.Text.Trim());
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion eventos botones
    }
}
