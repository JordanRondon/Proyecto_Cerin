
// --------------------------------------------------------------
// Nombre del archivo: preRegistrarCliente.cs
// Descripción: Clase que gestiona la interfaz de registro, edición,
//              búsqueda y eliminación de clientes.
// --------------------------------------------------------------

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
        // --------------------------------------------------------------
        // Atributos de la Clase
        // --------------------------------------------------------------
        private int id_Temporal = -1;

        public preRegistrarCliente()
        {
            InitializeComponent();
            ConfiguracionInicial();
            ConfigCabecera();
            ListarClientes();
        }

        #region CONFIGURACION DEL FORMULARIO

        /// <summary>
        /// Configura las columnas del DataGridView que muestra la lista de clientes.
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
        /// Configura la apariencia inicial de los controles del formulario.
        /// </summary>
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

        /// <summary>
        /// Configura la apariencia al editar de los controles del formulario.
        /// </summary>
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

        /// <summary>
        /// Limpia los cuadros de texto del formulario.
        /// </summary>
        private void LimpiarVariables()
        {
            txb_dni_cliente.Text = "";
            txb_apellidos_cliente.Text = "";
            txb_nombre_cliente.Text = "";
            txb_ruc_cliente.Text = "";
            txb_telefono_cliente.Text = "";
            txb_razonSocial_cliente.Text = "";
        }

        /// <summary>
        /// Configura los controles del formulario cuando se haga click en nuevo.
        /// </summary>
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

        /// <summary>
        /// Carga los clientes en el data grid view
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Nuevo".
        /// </summary>
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            ConfigNuevo();
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Buscar".
        /// </summary>
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txb_dni_cliente.Text.Length == 8)
            {
                DatosCliente(txb_dni_cliente.Text.Trim());
            }
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Guardar".
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Editar".
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Eliminar".
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Cancelar Registro".
        /// </summary>
        private void btn_cancelar_registro_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            LimpiarVariables();
        }

        /// <summary>
        /// Maneja el evento de hacer clic en alguna cela del dataGridView dgvClientes.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Buscar RUC".
        /// </summary>
        private void btnBuscarRuc_Click(object sender, EventArgs e)
        {
            if (txb_ruc_cliente.Text.Length == 11)
            {
                DatosRuc(txb_ruc_cliente.Text.Trim());
            }
        }
        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Cancelar".
        /// </summary>
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion eventos botones
    }
}
